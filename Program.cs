using AiConverter.Cli.Data.Models;
using AiConverter.Cli.DTOs;
using AiConverter.Cli.Misc;
using AiConverter.Cli.Repositories;
using AiConverter.Cli.Services;

namespace AiConverter.Cli;

public static class Program {
    public static async Task Main() {
        // var repo = new GnjConclusionsRepositoryFake();
        // await PrintTop3(repo);
        var aiService = new AiServiceFake();
        var answer = await TellAiYourName(aiService, "Bahrami!");
        Console.WriteLine($"Answer: {answer}");
    }

    private static GnjConclusionInputDto MapToInputDto(this GnjConclusion i) => new(
        i.Id,
        i.Title,
        i.KeyWord,
        i.KeyWord2,
        i.KeyWord3,
        i.KeyWord4,
        i.KeyWord5
    );

    private static async Task PrintTop3(IGnjConclusionsRepository repo) {
        var items = await repo.List(3);
        var inputs = items.Select(i => i.MapToInputDto());

        foreach (var i in inputs)
            Console.WriteLine($"[{i.Id}] {i.Title}");
    }

    private static async Task CompleteWithAi(IAiService aiService, GnjConclusionInputDto inputDto) {
        await aiService.AskAiAsync(inputDto.ToString());
    }

    private static async Task<string> TellAiYourName(IAiService aiService, string name) {
        var answer = await aiService.AskAiAsync($"My name is {name}");
        return answer;
    }
}

// Env.Load();
// var connStr = Environment.GetEnvironmentVariable("ASTRO_CALENDAR_DB_CONNECTION_STRING");
// using var astroDb = new AstroCalendarDbCtx(connStr!);
