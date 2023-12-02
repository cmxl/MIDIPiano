namespace MIDIPiano.Tests;

public class MidiFileTests
{
	private readonly ITestOutputHelper _outputHelper;

	public MidiFileTests(
		ITestOutputHelper outputHelper)
	{
		_outputHelper = outputHelper;
	}
	
	[Fact]
	public void CanLoadSampleMidiFile()
	{
		var midiFile = new MidiFile("Resources\\test.mid");
		Assert.Equal(1, midiFile.Format);
		Assert.Equal(6, midiFile.Tracks.Length);
		Assert.Equal(480, midiFile.TicksPerQuarterNote);
		
		foreach (var track in midiFile.Tracks)
		{
			foreach (var evt in track.TextEvents)
				_outputHelper.WriteLine(evt.ToString());

			foreach (var evt in track.MidiEvents)
				_outputHelper.WriteLine(evt.ToString());
		}
	}
}