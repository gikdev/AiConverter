using AiConverter.Cli.Data.Models;
using AiConverter.Cli.DTOs;
using AiConverter.Cli.Repositories;

namespace AiConverter.Cli;

public static class Program {
    static async Task Main() {
        await PrintTop3(
            new GnjConclusionsRepositoryFake()
        );
    }

    public static GnjConclusionInputDto MapToDto(this GnjConclusion i) => new(
        i.Id,
        i.Title,
        i.KeyWord,
        i.KeyWord2,
        i.KeyWord3,
        i.KeyWord4,
        i.KeyWord5
    );

    static async Task PrintTop3(IGnjConclusionsRepository repo) {
        var items = await repo.List(3);
        var inputs = items.Select(i => i.MapToDto());

        foreach (var i in inputs) {
            Console.WriteLine($"Id: {i.Id}, Keyword1: {i.Keyword1}");
        }
    }
}

// Env.Load();
// var connStr = Environment.GetEnvironmentVariable("ASTRO_CALENDAR_DB_CONNECTION_STRING");
// using var astroDb = new AstroCalendarDbCtx(connStr!);
