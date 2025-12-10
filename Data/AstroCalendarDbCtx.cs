using AiConverter.Cli.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AiConverter.Cli.Data;

public class AstroCalendarDbCtx(string connectionString) : DbContext {
    public DbSet<GnjConclusion> GnjConclusions => Set<GnjConclusion>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}
