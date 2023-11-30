using MIDIPiano.ViewModels;

namespace MIDIPiano.Models;

public readonly struct Tone
{
	public NoteEnum Note { get; init; }
	public int Segment { get; init; }
	public bool IsGroupTone => Note.ToString().Length > 1;

	public Tone(NoteEnum note, int segment)
	{
		Note = note;
		Segment = segment;
	}

	public static readonly Tone A0 = new(NoteEnum.A, 0);
	public static readonly Tone A1 = new(NoteEnum.A, 1);
	public static readonly Tone A2 = new(NoteEnum.A, 2);
	public static readonly Tone A3 = new(NoteEnum.A, 3);
	public static readonly Tone A4 = new(NoteEnum.A, 4);
	public static readonly Tone A5 = new(NoteEnum.A, 5);
	public static readonly Tone A6 = new(NoteEnum.A, 6);
	public static readonly Tone A7 = new(NoteEnum.A, 7);
	public static readonly Tone Ab1 = new(NoteEnum.Ab, 1);
	public static readonly Tone Ab2 = new(NoteEnum.Ab, 2);
	public static readonly Tone Ab3 = new(NoteEnum.Ab, 3);
	public static readonly Tone Ab4 = new(NoteEnum.Ab, 4);
	public static readonly Tone Ab5 = new(NoteEnum.Ab, 5);
	public static readonly Tone Ab6 = new(NoteEnum.Ab, 6);
	public static readonly Tone Ab7 = new(NoteEnum.Ab, 7);
	public static readonly Tone B0 = new(NoteEnum.B, 0);
	public static readonly Tone B1 = new(NoteEnum.B, 1);
	public static readonly Tone B2 = new(NoteEnum.B, 2);
	public static readonly Tone B3 = new(NoteEnum.B, 3);
	public static readonly Tone B4 = new(NoteEnum.B, 4);
	public static readonly Tone B5 = new(NoteEnum.B, 5);
	public static readonly Tone B6 = new(NoteEnum.B, 6);
	public static readonly Tone B7 = new(NoteEnum.B, 7);
	public static readonly Tone Bb0 = new(NoteEnum.Bb, 0);
	public static readonly Tone Bb1 = new(NoteEnum.Bb, 1);
	public static readonly Tone Bb2 = new(NoteEnum.Bb, 2);
	public static readonly Tone Bb3 = new(NoteEnum.Bb, 3);
	public static readonly Tone Bb4 = new(NoteEnum.Bb, 4);
	public static readonly Tone Bb5 = new(NoteEnum.Bb, 5);
	public static readonly Tone Bb6 = new(NoteEnum.Bb, 6);
	public static readonly Tone Bb7 = new(NoteEnum.Bb, 7);
	public static readonly Tone C1 = new(NoteEnum.C, 1);
	public static readonly Tone C2 = new(NoteEnum.C, 2);
	public static readonly Tone C3 = new(NoteEnum.C, 3);
	public static readonly Tone C4 = new(NoteEnum.C, 4);
	public static readonly Tone C5 = new(NoteEnum.C, 5);
	public static readonly Tone C6 = new(NoteEnum.C, 6);
	public static readonly Tone C7 = new(NoteEnum.C, 7);
	public static readonly Tone C8 = new(NoteEnum.C, 8);
	public static readonly Tone D1 = new(NoteEnum.D, 1);
	public static readonly Tone D2 = new(NoteEnum.D, 2);
	public static readonly Tone D3 = new(NoteEnum.D, 3);
	public static readonly Tone D4 = new(NoteEnum.D, 4);
	public static readonly Tone D5 = new(NoteEnum.D, 5);
	public static readonly Tone D6 = new(NoteEnum.D, 6);
	public static readonly Tone D7 = new(NoteEnum.D, 7);
	public static readonly Tone Db1 = new(NoteEnum.Db, 1);
	public static readonly Tone Db2 = new(NoteEnum.Db, 2);
	public static readonly Tone Db3 = new(NoteEnum.Db, 3);
	public static readonly Tone Db4 = new(NoteEnum.Db, 4);
	public static readonly Tone Db5 = new(NoteEnum.Db, 5);
	public static readonly Tone Db6 = new(NoteEnum.Db, 6);
	public static readonly Tone Db7 = new(NoteEnum.Db, 7);
	public static readonly Tone E1 = new(NoteEnum.E, 1);
	public static readonly Tone E2 = new(NoteEnum.E, 2);
	public static readonly Tone E3 = new(NoteEnum.E, 3);
	public static readonly Tone E4 = new(NoteEnum.E, 4);
	public static readonly Tone E5 = new(NoteEnum.E, 5);
	public static readonly Tone E6 = new(NoteEnum.E, 6);
	public static readonly Tone E7 = new(NoteEnum.E, 7);
	public static readonly Tone Eb1 = new(NoteEnum.Eb, 1);
	public static readonly Tone Eb2 = new(NoteEnum.Eb, 2);
	public static readonly Tone Eb3 = new(NoteEnum.Eb, 3);
	public static readonly Tone Eb4 = new(NoteEnum.Eb, 4);
	public static readonly Tone Eb5 = new(NoteEnum.Eb, 5);
	public static readonly Tone Eb6 = new(NoteEnum.Eb, 6);
	public static readonly Tone Eb7 = new(NoteEnum.Eb, 7);
	public static readonly Tone F1 = new(NoteEnum.F, 1);
	public static readonly Tone F2 = new(NoteEnum.F, 2);
	public static readonly Tone F3 = new(NoteEnum.F, 3);
	public static readonly Tone F4 = new(NoteEnum.F, 4);
	public static readonly Tone F5 = new(NoteEnum.F, 5);
	public static readonly Tone F6 = new(NoteEnum.F, 6);
	public static readonly Tone F7 = new(NoteEnum.F, 7);
	public static readonly Tone G1 = new(NoteEnum.G, 1);
	public static readonly Tone G2 = new(NoteEnum.G, 2);
	public static readonly Tone G3 = new(NoteEnum.G, 3);
	public static readonly Tone G4 = new(NoteEnum.G, 4);
	public static readonly Tone G5 = new(NoteEnum.G, 5);
	public static readonly Tone G6 = new(NoteEnum.G, 6);
	public static readonly Tone G7 = new(NoteEnum.G, 7);
	public static readonly Tone Gb1 = new(NoteEnum.Gb, 1);
	public static readonly Tone Gb2 = new(NoteEnum.Gb, 2);
	public static readonly Tone Gb3 = new(NoteEnum.Gb, 3);
	public static readonly Tone Gb4 = new(NoteEnum.Gb, 4);
	public static readonly Tone Gb5 = new(NoteEnum.Gb, 5);
	public static readonly Tone Gb6 = new(NoteEnum.Gb, 6);
	public static readonly Tone Gb7 = new(NoteEnum.Gb, 7);

	public static Tone FromNote(NoteVm note)
		=> new() { Note = note.Note, Segment = note.Segment };

	public static NoteVm ToNote(Tone tone)
		=> new() { Note = tone.Note, Segment = tone.Segment };
    
	public override bool Equals(object? obj)
		=> obj is Tone tone
		   && tone.Note == Note
		   && tone.Segment == Segment;

	public override int GetHashCode()
		=> Segment.GetHashCode() ^ Note.GetHashCode();

	public static bool operator ==(Tone x, Tone y)
		=> x.Segment == y.Segment
		   && x.Note == y.Note;
    
	public static bool operator !=(Tone x, Tone y)
		=> x.Segment != y.Segment
		   || x.Note != y.Note;
}