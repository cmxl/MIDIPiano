using System.Linq;
using MIDIPiano.Models;

namespace MIDIPiano.ViewModels;

public static class SongMapper
{
	public static IQueryable<SongVm> MapToVm(this IQueryable<Song> source)
		=> source.Select(x => x.MapToVm());

	public static SongVm MapToVm(this Song song)
		=> new()
		{
			Id = song.Id,
			Name = song.Name,
			Bpm = song.Bpm,
			Top = song.Segments.Select(x => new LaneVm
			{
				SegmentIndex = x.Index,
				Clef = x.TopClef,
				Tact = x.TopTact,
				AvailableTicks = GetAvailableTicksByTact(x.TopTact),
				TickDurationInMs = GetTickDurationByTactAndBpm(x.TopTact, song.Bpm),
				Notes = x.TopNotes.Notes.Select(y => new NoteVm
				{
					Position = y.Position,
					Note = y.Note,
					Segment = y.Segment,
					Type = y.Type,
					Ticks = GetTicksByTactAndType(x.TopTact, y.Type)
				}).ToList()
			}).ToList(),
			Bottom = song.Segments.Select(x => new LaneVm
			{
				SegmentIndex = x.Index,
				Clef = x.BottomClef,
				Tact = x.BottomTact,
				AvailableTicks = GetAvailableTicksByTact(x.BottomTact),
				TickDurationInMs = GetTickDurationByTactAndBpm(x.BottomTact, song.Bpm),
				Notes = x.BottomNotes.Notes.Select(y => new NoteVm
				{
					Position = y.Position,
					Note = y.Note,
					Segment = y.Segment,
					Type = y.Type,
					Ticks = GetTicksByTactAndType(x.BottomTact, y.Type)
				}).ToList()
			}).ToList()
		};

	private static int GetTicksByTactAndType(TactEnum tact, NoteTypeEnum type)
	{
		var available = GetAvailableTicksByTact(tact);
		return available / (int)type;
	}

	private static int GetTickDurationByTactAndBpm(TactEnum tact, int bpm)
	{
		var tactDuration = GetTactDurationByTactAndBpm(tact, bpm);
		return tactDuration / (int)NoteTypeEnum.ThirtySecond / (int)tact;
	}

	private static int GetTactDurationByTactAndBpm(TactEnum tact, int bpm)
	{
		var beatsPerTactPerMin = 60 * (int)tact;
		return beatsPerTactPerMin / bpm * 1000;
	}

	private static int GetAvailableTicksByTact(TactEnum tact)
		=> (int)tact * (int)NoteTypeEnum.ThirtySecond;
}