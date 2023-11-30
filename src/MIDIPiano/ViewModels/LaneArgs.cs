using System;

namespace MIDIPiano.ViewModels;

public class LaneArgs : EventArgs
{
	public int PosIndex { get;  }
	public int LaneIndex { get; }
	public int SegmentIndex { get; }

	public LaneArgs(int posIndex, int laneIndex, int segmentIndex)
	{
		PosIndex = posIndex;
		LaneIndex = laneIndex;
		SegmentIndex = segmentIndex;
	}
}