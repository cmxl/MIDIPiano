namespace MIDIPiano.Models;

public static class SongToMidiConverter
{
	public static MidiFile Convert(Song song)
	{
		using var ms = new MemoryStream();
		using var sw = new BinaryWriter(ms);

		//************************************
		// HEADER
		sw.Write("MThd"); // header marker
		sw.Write(6); // header length
		sw.Write((short)1); // format
		sw.Write((short)2); // tracks, we always have a bassline and a melody
		sw.Write(System.Convert.ToInt16(song.Bpm * 4)); // ticks per quarter note, I'd guess there is 4 ticks per beat as a standard
		//************************************


		//************************************
		// TRACK 0 - Melody
		sw.Write("MTrk"); // track marker

		// TODO: here we need to write the length if the track data
		// sw.Write(length);

		//************************************


		//************************************
		// TRACK 1 - Bassline
		sw.Write("MTrk"); // track marker

		// TODO: here we need to write the length if the track data
		// sw.Write(length);

		//************************************


		ms.Position = 0;

		return new MidiFile(ms);
	}
}