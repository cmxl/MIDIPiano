using dominikz.Domain.Enums.Music;

namespace dominikz.Domain.ViewModels.Songs;

public class NoteVm
{
    public int Position { get; set; }
    public int Segment { get; set; }
    public int Ticks { get; set; }
    public NoteTypeEnum Type { get; set; }
    public NoteEnum Note { get; set; }
}