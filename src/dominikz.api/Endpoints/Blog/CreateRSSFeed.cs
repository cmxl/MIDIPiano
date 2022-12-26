using System.ServiceModel.Syndication;
using System.Xml;
using dominikz.api.Utils;
using dominikz.shared.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dominikz.api.Endpoints.Blog;

[Tags("blog")]
[ApiController]
[Route("api/blog/rss")]
public class CreateRssFeed : ControllerBase
{
    private readonly IMediator _mediator;

    public CreateRssFeed(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ResponseCache(Duration = 86400)]
    public async Task<IActionResult> Execute(CancellationToken cancellationToken)
    {
        var rss = await _mediator.Send(new CreateRssFeedRequest(), cancellationToken);
        rss.Position = 0;
        return File(rss, "application/rss+xml");
    }
}

public class CreateRssFeedRequest : IRequest<Stream>
{
}

public class CreateRssFeedRequestHandler : IRequestHandler<CreateRssFeedRequest, Stream>
{
    private readonly ILinkCreator _linkCreator;
    private readonly IMediator _mediator;

    public CreateRssFeedRequestHandler(ILinkCreator linkCreator, IMediator mediator)
    {
        _linkCreator = linkCreator;
        _mediator = mediator;
    }

    public async Task<Stream> Handle(CreateRssFeedRequest request, CancellationToken cancellationToken)
    {
        var uri = _linkCreator.CreateRssUrl()!;
        var feed = new SyndicationFeed("dominikzettl.dev", "Blog Feed", uri);

        // add persons
        var authors = new Dictionary<ArticleSourceEnum, SyndicationPerson>()
        {
            { ArticleSourceEnum.Dz, new SyndicationPerson("dominikzettl@gmx.net", "Dominik Zettl", "https://dominikzettl.dev/") },
            { ArticleSourceEnum.Medlan, new SyndicationPerson("projectmedlan@gmail.com", "Markus Liebl", "https://www.medlan.de/") },
            { ArticleSourceEnum.Noobit, new SyndicationPerson("th.cmxl@gmail.com", "Tobias Haimerl", "https://www.noobit.dev/") }
        };

        foreach (var author in authors)
            feed.Authors.Add(author.Value);

        // add items
        var articles = await _mediator.Send(new SearchArticlesQuery(), cancellationToken);
        var items = articles.Select(x => new SyndicationItem
        {
            Id = x.Id.ToString(),
            Categories = { new SyndicationCategory(x.Category.ToString()) },
            PublishDate = x.Timestamp,
            Title = new TextSyndicationContent(x.Title),
            Links = { new SyndicationLink(new Uri(x.Path)) },
            Copyright = new TextSyndicationContent($"Copyright {x.Timestamp.Year}"),
            Authors = { authors[x.SourceEnum] }
        }).ToList();
        feed.Items = items;

        // add meta data
        foreach (var category in Enum.GetValues<ArticleCategoryEnum>())
            feed.Categories.Add(new SyndicationCategory((category.ToString())));

        feed.Copyright = new TextSyndicationContent($"Copyright {DateTime.Now.Year}");
        feed.Generator = "dominikzettl.dev";
        feed.LastUpdatedTime = DateTime.Now;
        feed.Id = Guid.NewGuid().ToString();

        // write stream
        var rss = new MemoryStream();
        await using var rssWriter = XmlWriter.Create(rss, new XmlWriterSettings() { Async = true });
        var rssFormatter = new Rss20FeedFormatter(feed);
        rssFormatter.WriteTo(rssWriter);
        return rss;
    }
}