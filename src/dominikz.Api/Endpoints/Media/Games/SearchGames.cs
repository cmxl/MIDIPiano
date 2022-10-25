﻿using dominikz.api.Mapper;
using dominikz.api.Models;
using dominikz.api.Provider;
using dominikz.api.Utils;
using dominikz.kernel;
using dominikz.kernel.Contracts;
using dominikz.kernel.Filter;
using dominikz.kernel.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dominikz.api.Endpoints.Games;

[Tags("medias/games")]
[ApiController]
[Route("api/medias/games")]
public class SearchGames : ControllerBase
{
    private readonly IMediator _mediator;

    public SearchGames(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Execute([FromQuery] GamesFilter filter, CancellationToken cancellationToken)
    {
        var query = new SearchGamesQuery()
        {
            Text = filter.Text,
            Genres = filter.Genres,
            Platform = filter.Platform
        };

        var vms = await _mediator.Send(query, cancellationToken);
        return Ok(vms);
    }
}

public class SearchGamesQuery : GamesFilter, IRequest<IReadOnlyCollection<GameVM>> { }

public class SearchGamesQueryHandler : IRequestHandler<SearchGamesQuery, IReadOnlyCollection<GameVM>>
{
    private readonly DatabaseContext _database;
    private readonly ILinkCreator _linkCreator;

    public SearchGamesQueryHandler(DatabaseContext database, ILinkCreator linkCreator)
    {
        _database = database;
        _linkCreator = linkCreator;
    }

    public async Task<IReadOnlyCollection<GameVM>> Handle(SearchGamesQuery request, CancellationToken cancellationToken)
    {
        var query = _database.From<Game>();

        if (!string.IsNullOrWhiteSpace(request.Text))
            query = query.Where(x => EF.Functions.Like(x.Title, $"%{request.Text}%"));

        if (request.Genres != GameGenresFlags.ALL)
            foreach (var genre in request.Genres.GetFlags())
                query = query.Where(x => x.Genres.HasFlag(genre));

        if (request.Platform is not null)
            query = query.Where(x => x.Platform == request.Platform);

        var games = await query.MapToVM()
            .OrderBy(x => x.Title)
            .ToListAsync(cancellationToken);

        // attach image url
        foreach (var game in games)
            if (game.Image is not null)
                game.Image.Url = _linkCreator.CreateImageUrl(game.Image.Id, ImageSizeEnum.Vertical)?.ToString() ?? string.Empty;

        return games;
    }
}