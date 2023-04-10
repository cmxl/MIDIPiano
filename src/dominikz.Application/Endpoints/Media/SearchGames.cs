﻿using dominikz.Application.Utils;
using dominikz.Domain.Enums;
using dominikz.Domain.Enums.Media;
using dominikz.Domain.Extensions;
using dominikz.Domain.Filter;
using dominikz.Domain.Models;
using dominikz.Domain.ViewModels.Media;
using dominikz.Infrastructure.Mapper;
using dominikz.Infrastructure.Provider;
using dominikz.Infrastructure.Provider.Database;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dominikz.Application.Endpoints.Media;

[Tags("medias/games")]
[Route("api/medias/games")]
public class SearchGames : EndpointController
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

public class SearchGamesQuery : GamesFilter, IRequest<IReadOnlyCollection<GameVm>> { }

public class SearchGamesQueryHandler : IRequestHandler<SearchGamesQuery, IReadOnlyCollection<GameVm>>
{
    private readonly DatabaseContext _database;
    private readonly ILinkCreator _linkCreator;
    private readonly CredentialsProvider _credentials;

    public SearchGamesQueryHandler(DatabaseContext database, ILinkCreator linkCreator, CredentialsProvider credentials)
    {
        _database = database;
        _linkCreator = linkCreator;
        _credentials = credentials;
    }

    public async Task<IReadOnlyCollection<GameVm>> Handle(SearchGamesQuery request, CancellationToken cancellationToken)
    {
        var query = _database.From<Game>();

        if (_credentials.HasPermission(PermissionFlags.Media) == false)
            query = query.Where(x => x.PublishDate != null);
        
        if (!string.IsNullOrWhiteSpace(request.Text))
            query = query.Where(x => EF.Functions.Like(x.Title, $"%{request.Text}%"));

        if (request.Genres is not null or  GameGenresFlags.All)
            foreach (var genre in request.Genres.Value.GetFlags())
                query = query.Where(x => x.Genres.HasFlag(genre));

        if (request.Platform is not null)
            query = query.Where(x => x.Platform == request.Platform);

        var games = await query.MapToVm()
            .OrderBy(x => x.Title)
            .ToListAsync(cancellationToken);

        // attach image url
        foreach (var game in games)
            if (game.ImageUrl != string.Empty)
                game.ImageUrl = _linkCreator.CreateImageUrl(game.ImageUrl, ImageSizeEnum.Vertical);

        return games;
    }
}