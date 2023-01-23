namespace dominikz.Domain.ViewModels.Songs;

public class SongVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Bpm { get; set; }
    public List<LaneVm> Top { get; set; } = new();
    public List<LaneVm> Bottom { get; set; } = new();
}