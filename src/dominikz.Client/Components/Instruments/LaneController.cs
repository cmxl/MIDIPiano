using System.Timers;
using dominikz.Domain.ViewModels.Songs;
using Timer = System.Timers.Timer;

namespace dominikz.Client.Components.Instruments;

public class LaneController
{
    public event EventHandler<LaneArgs>? LaneFinished;
    public event EventHandler<List<NoteArgs>>? NoteStarted;
    public event EventHandler<List<NoteArgs>>? NoteStopped;
    public bool Playing;

    private readonly int _posIndex;
    private readonly int _laneIndex;
    private readonly int _segmentIndex;
    private readonly int _availableTicks;
    private IReadOnlyCollection<NoteVm> _notes;
    private readonly Timer _timer;
    private int _tick;

    public LaneController(int posIndex, int laneIndex, LaneVm lane)
    {
        _posIndex = posIndex;
        _laneIndex = laneIndex;
        _segmentIndex = lane.SegmentIndex;
        _availableTicks = lane.AvailableTicks;
        _notes = lane.Notes.OrderBy(x => x.Position).ToList();

        _timer = new Timer(lane.TickDurationInMs);
        _timer.Elapsed += TickElapsed;
    }

    public void Play()
    {
        Playing = true;
        _timer.Start();
    }

    public void Stop()
    {
        Playing = false;
        _timer.Stop();
        _tick = 0;
    }

    public void Pause()
    {
        Playing = false;
        _timer.Stop();
    }

    private void TickElapsed(object? sender, ElapsedEventArgs args)
    {
        // stop notes from previous iteration
        var stopNotesArgs = _notes.Where(x => x.Position + x.Ticks == _tick)
            .Select(x => new NoteArgs(_posIndex, _laneIndex, _segmentIndex, x))
            .ToList();
        NoteStopped?.Invoke(this, stopNotesArgs);

        // trigger new notes
        var startNotesArgs = _notes.Where(x => x.Position == _tick)
            .Select(x => new NoteArgs(_posIndex, _laneIndex, _segmentIndex, x))
            .ToList();
        NoteStarted?.Invoke(this, startNotesArgs);

        _tick++;
        if (_tick < _availableTicks)
            return;

        // exit
        _timer.Stop();
        Playing = false;
        LaneFinished?.Invoke(this, new LaneArgs(_posIndex, _laneIndex, _segmentIndex));
    }
}