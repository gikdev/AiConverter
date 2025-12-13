using System.Text.Encodings.Web;
using System.Text.Json;
using AiConverter.Cli.Data.Models;
using AiConverter.Cli.DTOs;
using AiConverter.Cli.Misc;
using AiConverter.Cli.Repositories;
using AiConverter.Cli.Services;
using DotNetEnv;

namespace AiConverter.Cli;

public static class Program {
    public static async Task Main() {
        Env.Load();

        var repo = new GnjConclusionsRepositoryFake();
        var list = await repo.List();
        if (!list.Any()) return;

        var apiKey = Environment.GetEnvironmentVariable("LIARA_API_KEY");
        var baseUrl = Environment.GetEnvironmentVariable("LIARA_BASE_URL");
        var modelId = Environment.GetEnvironmentVariable("LIARA_MODEL_ID");
        var outputFile = Environment.GetEnvironmentVariable("OUTPUT_TEXT_FILE");

        if (
            string.IsNullOrWhiteSpace(apiKey) ||
            string.IsNullOrWhiteSpace(baseUrl) ||
            string.IsNullOrWhiteSpace(outputFile) ||
            string.IsNullOrWhiteSpace(modelId)
        ) throw new InvalidOperationException("Missing required AI environment variables.");

        var aiService = new AiService(apiKey, baseUrl, modelId);

        var jsonOptions = new JsonSerializerOptions {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true // makes JSON readable
        };

        // Collect all outputs
        var results = new List<object>();

        foreach (var gnj in list) {
            var answer = await aiService.AskAiAsync(
                Prompts.GetGnjConclusionPrompt(gnj.MapToInputDto())
            );

            var obj = JsonSerializer.Deserialize<object>(answer);
            results.Add(obj!);
        }

        // Serialize all results as a single JSON array
        var json = JsonSerializer.Serialize(results, jsonOptions);
        await File.WriteAllTextAsync(outputFile, json);
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
}

// Env.Load();
// var connStr = Environment.GetEnvironmentVariable("ASTRO_CALENDAR_DB_CONNECTION_STRING");
// using var astroDb = new AstroCalendarDbCtx(connStr!);
