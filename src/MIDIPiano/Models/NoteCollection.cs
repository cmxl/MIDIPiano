using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MIDIPiano.Models;

public readonly struct NoteCollection
{
	public NoteData[] Notes { get; }

	public NoteCollection(List<NoteData> notes)
	{
		Notes = notes.ToArray();
	}

	/// <summary>
	///     Structure: Note#Idx$Tick#Idx
	///     Example: 5E4#0:5D4#1$0#0:0#31:0#63:1#95
	/// </summary>
	public NoteCollection(string value)
	{
		var parts = value.Split('$');
		if (parts.Length != 2)
			throw new ArgumentException("Invalid note collection!");

		var idxString = parts[0];
		var notesWidthIdx = idxString.Split(':')
			.Select(x =>
			{
				var keys = x.Split('#');
				if (!int.TryParse(keys[1], out var id))
					throw new ArgumentException($"Invalid id '{x}'!");

				return new { Id = id, NoteAsString = keys[0] };
			})
			.ToDictionary(x => x.Id, x => x.NoteAsString);

		Notes = parts[1].Split(':')
			.Select(x =>
			{
				var keys = x.Split('#');
				if (!int.TryParse(keys[0], out var id))
					throw new ArgumentException($"Invalid id '{x}'!");

				if (!int.TryParse(keys[1], out var position))
					throw new ArgumentException($"Invalid position '{x}'!");

				return new NoteData(notesWidthIdx[id], position);
			})
			.ToArray();
	}

	public NoteData this[int index]
	{
		get => Notes[index];
		set => Notes[index] = value;
	}


	public override bool Equals([NotNullWhen(true)] object? obj)
		=> obj is NoteCollection collection
		   && collection.Notes.Length == Notes.Length
		   && !Notes.Where((t, i) => t != collection.Notes[i]).Any();

	public override int GetHashCode()
		=> Notes.GetHashCode();

	public static bool operator ==(NoteCollection x, NoteCollection y)
		=> x.Notes.Length == y.Notes.Length
		   && !x.Notes.Where((t, i) => t != y.Notes[i]).Any();

	public static bool operator !=(NoteCollection x, NoteCollection y)
		=> x.Notes.Length == y.Notes.Length
		   && x.Notes.Where((t, i) => t != y.Notes[i]).Any();

	/// <summary>
	///     Structure: Note#Idx$Tick#Idx
	///     Example: 5E4#0:5D4#1$0#0:0#31:0#63:1#95
	/// </summary>
	public override string ToString()
	{
		var notes = Notes.Distinct().ToList();
		var notesWidthIdx = new Dictionary<string, int>();
		for (var i = 0; i < notes.Count; i++)
			notesWidthIdx.Add(notes[i].ToString(), i);

		var idxString = string.Join(':', notesWidthIdx.Select(x => $"{x.Key}#{x.Value}"));
		var positions = new List<string>();
		foreach (var note in Notes)
		{
			var idx = notesWidthIdx[note.ToString()];
			positions.Add($"{idx}#{note.Position}");
		}

		var positionsString = string.Join(':', positions);
		return $"{idxString}${positionsString}";
	}
}