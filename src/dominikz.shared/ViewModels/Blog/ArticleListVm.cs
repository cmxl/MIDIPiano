using dominikz.shared.Contracts;

namespace dominikz.shared.ViewModels.Blog;

public class ArticleVm : IHasImageUrl
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public PersonVM? Author { get; set; }
    public DateTime? PublishDate { get; set; }
    public ArticleCategoryEnum Category { get; set; }
    public string AltCategories { get; set; } = string.Empty;
    public ArticleSourceEnum Source { get; set; }
    public bool Featured { get; set; }
    public string Path { get; set; } = new("about:blank");
}