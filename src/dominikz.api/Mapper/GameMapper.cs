﻿using dominikz.api.Models;
using dominikz.shared.ViewModels.Media;

namespace dominikz.api.Mapper;

public static class GameMapper
{
    public static IQueryable<GameVM> MapToVm(this IQueryable<Game> query)
        => query.Select(game => new GameVM()
        {
            Id = game.Id,
            Title = game.Title,
            Timestamp = game.Timestamp,
            ImageUrl = game.File!.Id.ToString(),
            Genres = game.Genres,
            Platform = game.Platform,
            Year = game.Year
        });
}
