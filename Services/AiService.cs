using System.ClientModel;
using OpenAI;
using OpenAI.Chat;

namespace AiConverter.Cli.Services;

public class AiService : IAiService {
    private readonly ChatClient _client;

    public AiService(
       string apiKey,
       string baseUrl,
       string model
    ) {
        var credential = new ApiKeyCredential(apiKey);
        var options = new OpenAIClientOptions {
            Endpoint = new Uri(baseUrl)
        };

        _client = new ChatClient(model, credential, options);
    }

    public async Task<string> AskAiAsync(string prompt) {
        var completion = await _client.CompleteChatAsync(prompt);

        var answer = completion.Value.Content[0].Text;

        return answer;
    }
}
