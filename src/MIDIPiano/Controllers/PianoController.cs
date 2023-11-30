using System;
using System.Collections.Generic;
using MIDIPiano.ViewModels;

namespace MIDIPiano.Controllers;

public class PianoController
{
	private readonly List<LaneController> _bottomCtrls = new();

	private readonly List<LaneController> _topCtrls = new();
	public bool Playing;

	public PianoController(SongVm song)
	{
		if (song.Top.Count != song.Bottom.Count)
			throw new ArgumentException("Top- and bottom lane count mismatch!");

		// create top lane controller
		for (var i = 0; i < song.Top.Count; i++)
		{
			var ctrl = new LaneController(0, i, song.Top[i]);
			ctrl.NoteStarted += (s, a) => NoteStarted?.Invoke(s, a);
			ctrl.NoteStopped += (s, a) => NoteStopped?.Invoke(s, a);
			ctrl.LaneFinished += OnLaneFinished;
			_topCtrls.Add(ctrl);
		}

		// create bottom lane controller
		for (var i = 0; i < song.Bottom.Count; i++)
		{
			var ctrl = new LaneController(1, i, song.Bottom[i]);
			ctrl.NoteStarted += (s, a) => NoteStarted?.Invoke(s, a);
			ctrl.NoteStopped += (s, a) => NoteStopped?.Invoke(s, a);
			ctrl.LaneFinished += OnLaneFinished;
			_bottomCtrls.Add(ctrl);
		}
	}

	public event EventHandler<List<NoteArgs>>? NoteStarted;
	public event EventHandler<List<NoteArgs>>? NoteStopped;
	public event EventHandler? SongFinished;

	public void Play()
	{
		Playing = true;
		_topCtrls[0].Play();
		_bottomCtrls[0].Play();
	}

	public void Stop()
	{
		Playing = false;
		_topCtrls[0].Stop();
		_bottomCtrls[0].Stop();
	}

	public void Pause()
	{
		Playing = false;
		_topCtrls[0].Pause();
		_bottomCtrls[0].Pause();
	}

	private void OnLaneFinished(object? sender, LaneArgs args)
	{
		var anyLaneUnfinishedYet = _topCtrls[args.LaneIndex].Playing || _bottomCtrls[args.LaneIndex].Playing;
		if (anyLaneUnfinishedYet)
			return;

		// stop
		var idx = args.LaneIndex + 1;
		if (idx == _topCtrls.Count)
		{
			Playing = false;
			SongFinished?.Invoke(this, EventArgs.Empty);
			return;
		}

		// call lanes in next segment
		_topCtrls[idx].Play();
		_bottomCtrls[idx].Play();
	}
}