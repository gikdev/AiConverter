using AiConverter.Cli.Data;
using AiConverter.Cli.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AiConverter.Cli.Repositories;

public class GnjConclusionsRepository(
    AstroCalendarDbCtx astroDb
) : IGnjConclusionsRepository {
    public async Task<IEnumerable<GnjConclusion>> List() {
        var items = await astroDb.GnjConclusions.ToListAsync();
        return items;
    }

    public async Task<IEnumerable<GnjConclusion>> List(int limit, int page = 1) {
        var items = await astroDb.GnjConclusions
            .Skip(limit * (page - 1))
            .Take(limit)
            .ToListAsync();

        return items;
    }
}
