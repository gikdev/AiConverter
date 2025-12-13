namespace AiConverter.Cli.DTOs;

public class GnjConclusionOutputDto {
    public Guid Id { get; set; }
    public string Nt { get; set; } = "";
    public IEnumerable<string> Kw { get; set; } = [];
}
