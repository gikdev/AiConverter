namespace AiConverter.Cli.DTOs;

public record GnjConclusionInputDto(
    Guid Id,
    string Title,
    string? Keyword1 = null,
    string? Keyword2 = null,
    string? Keyword3 = null,
    string? Keyword4 = null,
    string? Keyword5 = null
);
