using System.Collections.Generic;

namespace MIDIPiano.Models;

public static class PianoKeys
{
	public static readonly IReadOnlyCollection<Tone[]> All = new List<Tone[]>
	{
		new[] { Tone.A0, Tone.Bb0, Tone.B0 },
		new[] { Tone.C1, Tone.Db1, Tone.D1, Tone.Eb1, Tone.E1, Tone.F1, Tone.Gb1, Tone.G1, Tone.Ab1, Tone.A1, Tone.Bb1, Tone.B1 },
		new[] { Tone.C2, Tone.Db2, Tone.D2, Tone.Eb2, Tone.E2, Tone.F2, Tone.Gb2, Tone.G2, Tone.Ab2, Tone.A2, Tone.Bb2, Tone.B2 },
		new[] { Tone.C3, Tone.Db3, Tone.D3, Tone.Eb3, Tone.E3, Tone.F3, Tone.Gb3, Tone.G3, Tone.Ab3, Tone.A3, Tone.Bb3, Tone.B3 },
		new[] { Tone.C4, Tone.Db4, Tone.D4, Tone.Eb4, Tone.E4, Tone.F4, Tone.Gb4, Tone.G4, Tone.Ab4, Tone.A4, Tone.Bb4, Tone.B4 },
		new[] { Tone.C5, Tone.Db5, Tone.D5, Tone.Eb5, Tone.E5, Tone.F5, Tone.Gb5, Tone.G5, Tone.Ab5, Tone.A5, Tone.Bb5, Tone.B5 },
		new[] { Tone.C6, Tone.Db6, Tone.D6, Tone.Eb6, Tone.E6, Tone.F6, Tone.Gb6, Tone.G6, Tone.Ab6, Tone.A6, Tone.Bb6, Tone.B6 },
		new[] { Tone.C7, Tone.Db7, Tone.D7, Tone.Eb7, Tone.E7, Tone.F7, Tone.Gb7, Tone.G7, Tone.Ab7, Tone.A7, Tone.Bb7, Tone.B7 },
		new[] { Tone.C8 }
	};
}