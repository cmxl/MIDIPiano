﻿using dominikz.api.Mapper;
using dominikz.api.Models;
using dominikz.api.Provider;
using dominikz.api.Utils;
using dominikz.shared.Contracts;
using dominikz.shared.ViewModels.Media;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dominikz.api.Endpoints.Media;

[Tags("medias/movies")]
[Route("api/medias/movies")]
public class GetMovie : EndpointController
{
    private readonly IMediator _mediator;

    public GetMovie(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Execute(Guid id, CancellationToken cancellationToken)
    {
        var vm = await _mediator.Send(new GetMovieQuery(id), cancellationToken);
        if (vm is null)
            return NotFound();

        return Ok(vm);
    }
}

public class GetMovieQuery : IRequest<MovieDetailVM?>
{
    public Guid Id { get; set; }

    public GetMovieQuery(Guid id)
    {
        Id = id;
    }
}

public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDetailVM?>
{
    private readonly DatabaseContext _database;
    private readonly ILinkCreator _linkCreator;

    public GetMovieQueryHandler(DatabaseContext database, ILinkCreator linkCreator)
    {
        _database = database;
        _linkCreator = linkCreator;
    }

    public async Task<MovieDetailVM?> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = await _database.From<Movie>()
            .Include(x => x.File)
            .Include(x => x.Author!.File)
            .Include(x => x.MoviesPersonsMappings)
            .ThenInclude(x => x.Person!.File)
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        if (movie is null)
            return null;

        var vm = movie.MapToDetailVm();

        // attach image urls
        vm.Image!.Url = _linkCreator.CreateImageUrl(movie.File!.Id, ImageSizeEnum.Poster)?.ToString() ?? string.Empty;

        if (vm.Author?.Image is not null)
            vm.Author.Image.Url = _linkCreator.CreateImageUrl(vm.Author.Image.Id, ImageSizeEnum.Avatar)?.ToString() ?? string.Empty;

        foreach (var directorVm in vm.Directors)
            directorVm.Image!.Url = _linkCreator.CreateImageUrl(directorVm.Image!.Id, ImageSizeEnum.Avatar)?.ToString() ?? string.Empty;

        foreach (var writerVm in vm.Writers)
            writerVm.Image!.Url = _linkCreator.CreateImageUrl(writerVm.Image!.Id, ImageSizeEnum.Avatar)?.ToString() ?? string.Empty;

        foreach (var starVm in vm.Stars)
            starVm.Image!.Url = _linkCreator.CreateImageUrl(starVm.Image!.Id, ImageSizeEnum.Avatar)?.ToString() ?? string.Empty;

        return vm;
    }
}
