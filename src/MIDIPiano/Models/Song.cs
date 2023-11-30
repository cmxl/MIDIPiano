using System;
using System.Collections.Generic;

namespace MIDIPiano.Models;

public class Song
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public int Bpm { get; set; }

	public IReadOnlyCollection<SongSegment> Segments { get; set; } = new List<SongSegment>();
}