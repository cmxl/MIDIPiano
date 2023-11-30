using MIDIPiano.Models;

namespace MIDIPiano;

//====================================================================================================
// GENERATED VIA DATABASE SELECT AS AN EXAMPLE FOR THE PIANO COMPONENT
//====================================================================================================
// select 
// 	'new SongSegment { Index = ' + cast([index] as varchar(2)) + ', TopClef = ClefEnum.Treble, TopTact = TactEnum.T4Of4, TopNotes = new NoteCollection("' + topnotes +  '"), BottomClef = ClefEnum.Bass, BottomTact = TactEnum.T4Of4, BottomNotes = new NoteCollection("' + bottomnotes +  '") },'
// from 
// (VALUES 
// 	(0,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4G4#0:4B4#1$0#0:0#32:0#64:1#96',1,4,'3E8#0:3B8#1:3G8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(1,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'5E4#0:5D4#1$0#0:0#32:0#64:1#96',1,4,'3C8#0:3G8#1:3E8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(2,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B4#0$0#0:0#32:0#64:0#96',1,4,'3G8#0:4D8#1:3B8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(3,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4F4#0:4E4#1$0#0:0#32:0#64:1#96',1,4,'3D8#0:3A8#1:3F8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(4,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4G8#0:4E8#1:4A8#2$0#16:0#32:1#48:0#64:1#80:0#96:2#112',1,4,'3E8#0:3B8#1:3G8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(5,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B4#0:4G8#1:4D8#2$0#0:0#16:1#32:1#48:2#64:0#80',1,4,'3C8#0:3G8#1:3E8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(6,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B8#0:4G8#1$0#0:1#80:1#96:1#112',1,4,'3G8#0:4D8#1:3B8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(7,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4F4#0:4F8#1:4E8#2:4G4#3$0#0:1#48:1#64:2#80:3#96',1,4,'3D8#0:3A8#1:3F8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(8,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4A8#0:4E8#1:4B8#2$0#16:0#32:1#48:0#64:1#80:0#96:2#112',1,4,'3E8#0:3B8#1:3G8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(9,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B4#0:4G8#1:5D8#2$0#0:1#32:1#48:2#64:0#80',1,4,'3C8#0:3G8#1:3E8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(10,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4G8#0:4A8#1$0#80:0#96:1#112',1,4,'3G8#0:4D8#1:3B8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(11,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4A2#0:4B8#1$0#0:1#80:1#96:1#112',1,4,'3D8#0:3A8#1:3F8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(12,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4G4#0:4B4#1$0#0:1#0:0#32:0#64:1#96',1,4,'3G1#0:3E1#1:2A1#2$0#0:0#1:0#2'),
// 	(13,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'5E4#0:5E8#1:4B8#2:5D8#3$0#0:0#32:1#64:2#80:2#96:3#96:2#112',1,4,'3G1#0:3E1#1:2B1#2$0#0:0#1:0#2'),
// 	(14,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B4#0$0#0:0#32:0#64:0#96',1,4,'3B1#0:3G1#1:3D1#2$0#0:0#1:0#2'),
// 	(15,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4F4#0:4F8#1:4B8#2$0#0:0#32:1#64:2#80:1#96:2#96:2#112',1,4,'3A1#0:3F1#1:3D1#2$0#0:0#1:0#2'),
// 	(16,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4G2#0:4B2#1:4G16#2:4A16#3:4A8#4:4B16#5$0#0:1#0:2#80:3#88:4#96:3#112:5#120',1,4,'3G4#0:3E4#1:2B4#2:3G2#3:3E2#4:2B2#5$0#0:1#0:2#0:3#32:4#32:5#32:0#96:1#96:2#96'),
// 	(17,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4A8#0:4G8#1:4G4#2:4B8#3$0#0:1#16:2#32:3#80:3#96:3#112',1,4,'3G4#0:3E4#1:3C4#2:3G2#3:3E2#4:3C2#5$0#0:1#0:2#0:3#32:4#32:5#32:0#96:1#96:2#96'),
// 	(18,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B2#0:4G16#1:4G8#2:4A16#3$0#0:1#60:1#70:2#80:1#100:3#110',1,4,'3B8#0:3B2#1:3G8#2:3D8#3:3G2#4:3D2#5$0#0:1#32:0#80:2#0:3#0:4#32:5#32:2#80:3#80'),
// 	(19,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4F8#0:4G2#1$0#0:0#21:0#42:1#63',1,4,'3A8#0:3A2#1:3F8#2:3D8#3:3F2#4:3D2#5$0#0:1#42:2#0:3#0:4#42:5#42'),
// 	(20,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B8#0$0#32:0#64:0#96',1,4,'3A2#0:3F2#1:3D2#2$0#0:1#0:2#0'),
// 	(21,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B2#0:4G8#1$0#0:1#112',1,4,'3E8#0:3B8#1:3G8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(22,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4E8#0:4D2#1:4G8#2:5D8#3:5D16#4:4B16#5$0#0:1#16:2#80:3#96:4#112:5#120',1,4,'3C8#0:3G8#1:3E8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(23,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B2#0:4G8#1:5D8#2:5D16#3:4B16#4$0#0:1#80:2#96:3#112:4#120',1,4,'3G8#0:4D8#1:3B8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(24,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B4#0:4A8#1:4B8#2$0#0:1#48:1#64:2#80:2#96:2#112',1,4,'3D8#0:3A8#1:3F8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(25,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B2#0:4G8#1:4E8#2:5C8#3$0#0:1#64:1#88:2#96:3#112',1,4,'3E8#0:3B8#1:3G8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(26,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'5C2#0:5D8#1$0#0:1#112',1,4,'3C8#0:3G8#1:3E8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(27,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'4B8#0:5D8#1:4A16#2:5C16#3$0#0:1#16:0#32:1#48:0#64:1#80:0#96:2#112:3#120',1,4,'3G8#0:4D8#1:3B8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112'),
// 	(28,'60a00835-57b3-11ed-8c93-00d861ff2f96',0,4,'5C4#0:4C8#1:5E4#2:4B4#3:5D4#4$0#0:1#48:2#64:0#64:3#96:4#96',1,4,'3D8#0:3A8#1:3F8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112')
// ) x([index], songid, topclef, toptact, topnotes, bottomclef, bottomtact, bottomnotes);
//====================================================================================================
public static class MusicSheets
{
	public static readonly Song FadedByAlanWalker = new Song
	{
		Bpm = 90,
		Name = "Faded - Alan Walker",
		Segments = new[]
		{
			new SongSegment
			{
				Index = 0,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4G4#0:4B4#1$0#0:0#32:0#64:1#96"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3E8#0:3B8#1:3G8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 1,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("5E4#0:5D4#1$0#0:0#32:0#64:1#96"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3C8#0:3G8#1:3E8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 2,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B4#0$0#0:0#32:0#64:0#96"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3G8#0:4D8#1:3B8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 3,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4F4#0:4E4#1$0#0:0#32:0#64:1#96"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3D8#0:3A8#1:3F8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 4,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4G8#0:4E8#1:4A8#2$0#16:0#32:1#48:0#64:1#80:0#96:2#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3E8#0:3B8#1:3G8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 5,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B4#0:4G8#1:4D8#2$0#0:0#16:1#32:1#48:2#64:0#80"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3C8#0:3G8#1:3E8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 6,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B8#0:4G8#1$0#0:1#80:1#96:1#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3G8#0:4D8#1:3B8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 7,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4F4#0:4F8#1:4E8#2:4G4#3$0#0:1#48:1#64:2#80:3#96"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3D8#0:3A8#1:3F8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 8,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4A8#0:4E8#1:4B8#2$0#16:0#32:1#48:0#64:1#80:0#96:2#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3E8#0:3B8#1:3G8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 9,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B4#0:4G8#1:5D8#2$0#0:1#32:1#48:2#64:0#80"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3C8#0:3G8#1:3E8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 10,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4G8#0:4A8#1$0#80:0#96:1#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3G8#0:4D8#1:3B8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 11,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4A2#0:4B8#1$0#0:1#80:1#96:1#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3D8#0:3A8#1:3F8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 12,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4G4#0:4B4#1$0#0:1#0:0#32:0#64:1#96"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3G1#0:3E1#1:2A1#2$0#0:0#1:0#2")
			},
			new SongSegment
			{
				Index = 13,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("5E4#0:5E8#1:4B8#2:5D8#3$0#0:0#32:1#64:2#80:2#96:3#96:2#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3G1#0:3E1#1:2B1#2$0#0:0#1:0#2")
			},
			new SongSegment
			{
				Index = 14,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B4#0$0#0:0#32:0#64:0#96"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3B1#0:3G1#1:3D1#2$0#0:0#1:0#2")
			},
			new SongSegment
			{
				Index = 15,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4F4#0:4F8#1:4B8#2$0#0:0#32:1#64:2#80:1#96:2#96:2#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3A1#0:3F1#1:3D1#2$0#0:0#1:0#2")
			},
			new SongSegment
			{
				Index = 16,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4G2#0:4B2#1:4G16#2:4A16#3:4A8#4:4B16#5$0#0:1#0:2#80:3#88:4#96:3#112:5#120"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3G4#0:3E4#1:2B4#2:3G2#3:3E2#4:2B2#5$0#0:1#0:2#0:3#32:4#32:5#32:0#96:1#96:2#96")
			},
			new SongSegment
			{
				Index = 17,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4A8#0:4G8#1:4G4#2:4B8#3$0#0:1#16:2#32:3#80:3#96:3#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3G4#0:3E4#1:3C4#2:3G2#3:3E2#4:3C2#5$0#0:1#0:2#0:3#32:4#32:5#32:0#96:1#96:2#96")
			},
			new SongSegment
			{
				Index = 18,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B2#0:4G16#1:4G8#2:4A16#3$0#0:1#60:1#70:2#80:1#100:3#110"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3B8#0:3B2#1:3G8#2:3D8#3:3G2#4:3D2#5$0#0:1#32:0#80:2#0:3#0:4#32:5#32:2#80:3#80")
			},
			new SongSegment
			{
				Index = 19,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4F8#0:4G2#1$0#0:0#21:0#42:1#63"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3A8#0:3A2#1:3F8#2:3D8#3:3F2#4:3D2#5$0#0:1#42:2#0:3#0:4#42:5#42")
			},
			new SongSegment
			{
				Index = 20,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B8#0$0#32:0#64:0#96"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3A2#0:3F2#1:3D2#2$0#0:1#0:2#0")
			},
			new SongSegment
			{
				Index = 21,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B2#0:4G8#1$0#0:1#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3E8#0:3B8#1:3G8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 22,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4E8#0:4D2#1:4G8#2:5D8#3:5D16#4:4B16#5$0#0:1#16:2#80:3#96:4#112:5#120"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3C8#0:3G8#1:3E8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 23,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B2#0:4G8#1:5D8#2:5D16#3:4B16#4$0#0:1#80:2#96:3#112:4#120"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3G8#0:4D8#1:3B8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 24,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B4#0:4A8#1:4B8#2$0#0:1#48:1#64:2#80:2#96:2#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3D8#0:3A8#1:3F8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 25,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B2#0:4G8#1:4E8#2:5C8#3$0#0:1#64:1#88:2#96:3#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3E8#0:3B8#1:3G8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 26,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("5C2#0:5D8#1$0#0:1#112"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3C8#0:3G8#1:3E8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 27,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("4B8#0:5D8#1:4A16#2:5C16#3$0#0:1#16:0#32:1#48:0#64:1#80:0#96:2#112:3#120"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3G8#0:4D8#1:3B8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
			new SongSegment
			{
				Index = 28,
				TopClef = ClefEnum.Treble,
				TopTact = TactEnum.T4Of4,
				TopNotes = new NoteCollection("5C4#0:4C8#1:5E4#2:4B4#3:5D4#4$0#0:1#48:2#64:0#64:3#96:4#96"),
				BottomClef = ClefEnum.Bass,
				BottomTact = TactEnum.T4Of4,
				BottomNotes = new NoteCollection("3D8#0:3A8#1:3F8#2$0#0:1#16:2#32:1#48:0#64:1#80:2#96:1#112")
			},
		}
	};
}