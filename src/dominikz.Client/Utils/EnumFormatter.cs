﻿using dominikz.Domain.Enums.Blog;
using dominikz.Domain.Enums.Cookbook;
using dominikz.Domain.Enums.Media;

namespace dominikz.Client.Utils;

public static class EnumFormatter
{
    private const string Default = "Unknown";

    public static string ToString<TEnum>(IReadOnlyCollection<TEnum> values) where TEnum : struct
        => string.Join(", ", values.Select(ToString));

    public static string ToString<TEnum>(TEnum value) where TEnum : struct
    {
        if (value is MediaCategoryEnum mediaCategory)
            return ToString(mediaCategory);
        if (value is MovieGenresFlags movieGenre)
            return ToString(movieGenre);
        if (value is ArticleCategoryEnum articleCategory)
            return ToString(articleCategory);
        if (value is ArticleSourceEnum articleSource)
            return ToString(articleSource);
        if (value is GamePlatformEnum platform)
            return ToString(platform);
        if (value is GameGenresFlags gameGenre)
            return ToString(gameGenre);
        if (value is BookLanguageEnum language)
            return ToString(language);
        if (value is BookGenresFlags bookGenre)
            return ToString(bookGenre);
        if (value is RecipeFlags recipeFlag)
            return ToString(recipeFlag);
        if (value is RecipeType recipeType)
            return ToString(recipeType);
        
        return value.ToString()!;
    }

    private static string ToString(MediaCategoryEnum category)
        => category switch
        {
            MediaCategoryEnum.Movie => "🍿 Movie",
            MediaCategoryEnum.Book => "📖 Book",
            MediaCategoryEnum.Game => "🎮 Game",
            _ => Default
        };

    private static string ToString(MovieGenresFlags genre)
        => genre switch
        {
            MovieGenresFlags.All => string.Empty,
            MovieGenresFlags.Horror => "👻 Horror",
            MovieGenresFlags.Drama => "🎭 Drama",
            MovieGenresFlags.Mystery => "🔮 Mystery",
            MovieGenresFlags.Thriller => "🧟 Thriller",
            MovieGenresFlags.Action => "📣 Action",
            MovieGenresFlags.Adventure => "🗺 Adventure",
            MovieGenresFlags.Fantasy => "🦄 Fantasy",
            MovieGenresFlags.Comedy => "🎤 Comedy",
            MovieGenresFlags.Western => "🐴 Western",
            MovieGenresFlags.SciFi => "🚀 SciFi",
            MovieGenresFlags.Animation => "🐇 Animation",
            MovieGenresFlags.Crime => "🎈 Crime",
            MovieGenresFlags.Musical => "🎻 Musical",
            MovieGenresFlags.War => "🔫 War",
            MovieGenresFlags.Romance => "♥ Romance",
            MovieGenresFlags.Biography => "🎩 Biography",
            MovieGenresFlags.History => "📙 History",
            MovieGenresFlags.Family => "👪 Family",
            _ => Default
        };

    private static string ToString(ArticleCategoryEnum category)
        => category switch
        {
            ArticleCategoryEnum.Coding => "💾 Coding",
            ArticleCategoryEnum.Movie => "🎞 Movie",
            ArticleCategoryEnum.Project => "🚀 Project",
            ArticleCategoryEnum.Gaming => "🎮 Gaming",
            ArticleCategoryEnum.Travel => "✈ Travel",
            ArticleCategoryEnum.Birds => "🐤 Birds",
            ArticleCategoryEnum.Thoughts => "💡 Thoughts",
            ArticleCategoryEnum.Music => "🎸 Music",
            _ => Default
        };

    private static string ToString(GamePlatformEnum platform)
        => platform switch
        {
            GamePlatformEnum.Pc => "🖥 PC",
            GamePlatformEnum.Ps4 => "🎮 PS4",
            GamePlatformEnum.Switch => "🎮 Nintendo Switch",
            _ => Default
        };

    private static string ToString(GameGenresFlags genre)
        => genre switch
        {
            GameGenresFlags.All => string.Empty,
            GameGenresFlags.VirtualReality => "👓 VR",
            GameGenresFlags.Indie => "🕹 Indie",
            GameGenresFlags.Survival => "🎒 Survival",
            GameGenresFlags.Horror => "👻 Horror",
            GameGenresFlags.Action => "📣 Action",
            GameGenresFlags.Puzzle => "🧩 Puzzle",
            GameGenresFlags.OpenWorld => "🌎 Open World",
            GameGenresFlags.Adventure => "🗺 Adventure",
            GameGenresFlags.Shooter => "🔫 Shooter",
            GameGenresFlags.RealTime => "🕑 Realtime",
            GameGenresFlags.Strategy => "✏ Strategy",
            GameGenresFlags.Tactic => "🗒 Tactic",
            GameGenresFlags.Rpg => "🌲 RPG",
            GameGenresFlags.Sandbox => "📦 Sandbox",
            GameGenresFlags.Simulation => "⌨ Simulation",
            GameGenresFlags.Stealth => "🥷 Stealth",
            GameGenresFlags.Racing => "🚗 Racing",
            GameGenresFlags.Construction => "🚧 Construction",
            GameGenresFlags.JumpNRun => "🔘 Jump and Run",
            GameGenresFlags.BattleRoyal => "🏆 Battle Royal",
            GameGenresFlags.HackAndSlay => "⚔ Hack and Slay",
            GameGenresFlags.ClickAndPoint => "🖱 Click & Point",
            GameGenresFlags.Party => "🎈 Party",
            _ => Default
        };

    private static string ToString(BookGenresFlags genre)
        => genre switch
        {
            BookGenresFlags.All => string.Empty,
            BookGenresFlags.Crime => "🎈 Crime",
            BookGenresFlags.Fantasy => "🦄 Fantasy",
            BookGenresFlags.Adventure => "🗺 Adventure",
            BookGenresFlags.Horror => "👻 Horror",
            BookGenresFlags.SciFi => "🚀 SciFi",
            BookGenresFlags.Novel => "📕 Novel",
            BookGenresFlags.Thriller => "🧟 Thriller",
            BookGenresFlags.Dystopia => "💣 Dystopia",
            BookGenresFlags.NonFiction => "📚 Non-Fiction",
            BookGenresFlags.Advising => "🎓 Advising",
            BookGenresFlags.Romance => "♥ Romance",
            BookGenresFlags.Humor => "🎤 Comedy",
            _ => Default
        };

    private static string ToString(BookLanguageEnum language)
        => language switch
        {
            BookLanguageEnum.German => "German",
            BookLanguageEnum.English => "English",
            _ => Default
        };

    private static string ToString(ArticleSourceEnum sourceEnum)
        => sourceEnum switch
        {
            ArticleSourceEnum.Dz => "Dominik",
            ArticleSourceEnum.Medlan => "Medlan",
            ArticleSourceEnum.Noobit => "Noobit",
            _ => Default
        };

    private static string ToString(RecipeFlags recipe)
        => recipe switch
        {
            RecipeFlags.Vegetarian => "🍏 Vegetarian",
            RecipeFlags.Vegan => "🥬 Vegan",
            RecipeFlags.GlutenFree => "🌾 Gluten Free",
            RecipeFlags.LactoseFree => "🥛 Lactose Free",
            _ => Default
        };

    private static string ToString(RecipeType recipe)
        => recipe switch
        {
            RecipeType.Starter => "🍲 Starter",
            RecipeType.Main => "🥗 Main",
            RecipeType.Dessert => "🍨 Dessert",
            RecipeType.Cake => "🧁 Cake",
            _ => throw new ArgumentOutOfRangeException(nameof(recipe), recipe, null)
        };
    
    public static string ToIcon(RecipeType recipe)
        => recipe switch
        {
            RecipeType.Starter => "🍲",
            RecipeType.Main => "🥗",
            RecipeType.Dessert => "🍨",
            RecipeType.Cake => "🧁",
            _ => throw new ArgumentOutOfRangeException(nameof(recipe), recipe, null)
        };
    
    public static string ToText(RecipeType recipe)
        => recipe switch
        {
            RecipeType.Starter => "Starter",
            RecipeType.Main => "Main",
            RecipeType.Dessert => "Dessert",
            RecipeType.Cake => "Cake",
            _ => throw new ArgumentOutOfRangeException(nameof(recipe), recipe, null)
        };


    public static string ToIcon(RecipeFlags recipe)
        => recipe switch
        {
            RecipeFlags.Vegetarian => "🍏",
            RecipeFlags.Vegan => "🥬",
            RecipeFlags.GlutenFree => "🌾",
            RecipeFlags.LactoseFree => "🥛",
            _ => Default
        };
    
    public static string ToText(RecipeFlags recipe)
        => recipe switch
        {
            RecipeFlags.Vegetarian => "Vegetarian",
            RecipeFlags.Vegan => "Vegan",
            RecipeFlags.GlutenFree => "Gluten Free",
            RecipeFlags.LactoseFree => "Lactose Free",
            _ => Default
        };
}