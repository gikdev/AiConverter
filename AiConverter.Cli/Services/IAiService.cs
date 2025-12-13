namespace AiConverter.Cli.Services;

public interface IAiService {
    Task<string> AskAiAsync(string prompt);
}
