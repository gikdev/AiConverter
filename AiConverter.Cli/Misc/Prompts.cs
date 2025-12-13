using AiConverter.Cli.DTOs;

namespace AiConverter.Cli.Misc;

public static class Prompts {
    private static readonly string PromptTemplate = File.ReadAllText("Misc/GnjConclusionPrompt.txt");

    public static string GetGnjConclusionPrompt(GnjConclusionInputDto input) {
        return PromptTemplate
            .Replace("{Id}", input.Id.ToString())
            .Replace("{Title}", input.Title ?? "")
            .Replace("{Keyword1}", input.Keyword1 ?? "(none)")
            .Replace("{Keyword2}", input.Keyword2 ?? "(none)")
            .Replace("{Keyword3}", input.Keyword3 ?? "(none)")
            .Replace("{Keyword4}", input.Keyword4 ?? "(none)")
            .Replace("{Keyword5}", input.Keyword5 ?? "(none)");
    }
}
