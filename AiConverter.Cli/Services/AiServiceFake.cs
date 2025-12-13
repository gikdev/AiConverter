namespace AiConverter.Cli.Services;

public class AiServiceFake : IAiService {
    public Task<string> AskAiAsync(string prompt) {
        Console.WriteLine(prompt);

        return Task.FromResult($"FAKE_RESPONSE: {prompt}");
    }
}
