using System.ClientModel;
using System.Text.Json;
using AiConverter.Cli.DTOs;
using AiConverter.Cli.Misc;
using OpenAI;
using OpenAI.Chat;

namespace AiConverter.Cli.Services;

public class AiService : IAiService {
    private readonly ChatClient _client;
    private readonly JsonSerializerOptions _serializerOptions = new() {
        PropertyNameCaseInsensitive = true
    };

    public AiService(
       string apiKey,
       string baseUrl,
       string model
    ) {
        var credential = new ApiKeyCredential(apiKey);
        var options = new OpenAIClientOptions {
            Endpoint = new Uri(baseUrl),
        };

        _client = new ChatClient(model, credential, options);
    }

    public async Task<string> AskAiAsync(string prompt) {
        var completion = await _client.CompleteChatAsync(prompt);

        var answer = completion.Value.Content[0].Text;

        return answer;
    }

    public async Task<GnjConclusionOutputDto?> AskAiStructuredAsync(
        GnjConclusionInputDto input
    ) {
        var prompt = Prompts.GetGnjConclusionPrompt(input);
        var completion = await _client.CompleteChatAsync(prompt);
        var raw = completion.Value.Content[0].Text;

        try {
            return JsonSerializer.Deserialize<GnjConclusionOutputDto>(raw, _serializerOptions);
        }
        catch {
            Console.WriteLine("Failed to parse AI output:");
            Console.WriteLine(raw);
            return null;
        }
    }
}
