using System.Collections.Generic;
using MIDIPiano.Models;

namespace MIDIPiano.ViewModels;

public class LaneVm
{
	public int SegmentIndex { get; set; }
	public int TickDurationInMs { get; set; }
	public int AvailableTicks { get; set; }
	public ClefEnum Clef { get; set; }
	public TactEnum Tact { get; set; }
	public List<NoteVm> Notes { get; set; } = new();
}