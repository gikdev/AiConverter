using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AiConverter.Cli.Data.Models;

[Table("GnjConclusions")]
public class GnjConclusion {
    [Key]
    public Guid Id { get; set; }

    public int Order { get; set; }

    [Required]
    [MaxLength(2000)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string? NewTitle { get; set; }

    [MaxLength(200)]
    public string? KeyWord { get; set; }

    [MaxLength(200)]
    public string? KeyWord2 { get; set; }

    [MaxLength(200)]
    public string? KeyWord3 { get; set; }

    [MaxLength(200)]
    public string? KeyWord4 { get; set; }

    [MaxLength(200)]
    public string? KeyWord5 { get; set; }

    public DateTime? DateCreate { get; set; }

    [MaxLength(200)]
    public string? KeyWordAi { get; set; }

    [MaxLength(200)]
    public string? KeyWordAi2 { get; set; }

    [MaxLength(200)]
    public string? KeyWordAi3 { get; set; }

    [MaxLength(200)]
    public string? KeyWordAi4 { get; set; }

    [MaxLength(200)]
    public string? KeyWordAi5 { get; set; }

    public DateTime? LastModified { get; set; }

    [Column("isAiGenrateNewTitle")]
    public bool? IsAiGenrateNewTitle { get; set; }

    [Column("isConfirmedNewTitle")]
    public bool? IsConfirmedNewTitle { get; set; }
}
