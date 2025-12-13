using System.Text.Json;
using AiConverter.Cli.Data.Models;

namespace AiConverter.Cli.Repositories;

public class GnjConclusionsRepositoryFake() : IGnjConclusionsRepository {
    private readonly string _path = "./sample-data2.json";

    public async Task<IEnumerable<GnjConclusion>> List() {
        if (!File.Exists(_path)) return [];

        var json = await File.ReadAllTextAsync(_path);
        var items = JsonSerializer.Deserialize<List<GnjConclusion>>(json);

        return items ?? Enumerable.Empty<GnjConclusion>();
    }

    public async Task<IEnumerable<GnjConclusion>> List(int limit, int page = 1) {
        if (!File.Exists(_path)) return [];

        var json = await File.ReadAllTextAsync(_path);
        var items = JsonSerializer.Deserialize<List<GnjConclusion>>(json) ?? [];

        page = Math.Max(page, 1);

        return items
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToList();
    }
}
