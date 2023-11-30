using System;
using System.Diagnostics.CodeAnalysis;

namespace MIDIPiano.Models;

public readonly struct NoteData
{
	public int Position { get; }
	public NoteTypeEnum Type { get; }
	public NoteEnum Note { get; }
	public int Segment { get; }

	public NoteData(NoteTypeEnum type, NoteEnum note, int segment, int position)
	{
		Type = type;
		Note = note;
		Segment = segment;
		Position = position;
	}

	/// <summary>
	///     Structure: Segment | Note | Type
	///     Example: Segment:4; Note:G; Type:Quarter; -> 4G4
	/// </summary>
	public NoteData(string key, int position)
	{
		if (key.Length < 3)
			throw new ArgumentException("Invalid note key!");

		if (!int.TryParse(key[0].ToString(), out var segment))
			throw new ArgumentException("Invalid segment!");

		if (!Enum.TryParse<NoteEnum>(key[1].ToString(), out var note))
			throw new ArgumentException("Invalid note!");

		if (!Enum.TryParse<NoteTypeEnum>(key[2..], out var type))
			throw new ArgumentException("Invalid type!");

		Position = position;
		Segment = segment;
		Note = note;
		Type = type;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is NoteData data
		   && data.Segment == Segment
		   && data.Type == Type
		   && data.Note == Note;

	public override int GetHashCode()
		=> Segment.GetHashCode() ^ Type.GetHashCode() ^ Note.GetHashCode();

	public static bool operator ==(NoteData x, NoteData y)
		=> x.Segment == y.Segment
		   && x.Type == y.Type
		   && x.Note == y.Note;

	public static bool operator !=(NoteData x, NoteData y)
		=> x.Segment != y.Segment
		   || x.Type != y.Type
		   || x.Note != y.Note;

	/// <summary>
	///     Structure: Segment | Note | Type
	///     Example: Segment:4; Note:G; Type:Quarter; -> 4G4
	/// </summary>
	public override string ToString()
		=> $"{Segment}{Note}{(int)Type}";
}