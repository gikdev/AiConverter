using AiConverter.Cli.Data.Models;

namespace AiConverter.Cli.Repositories;

public interface IGnjConclusionsRepository {
    public Task<IEnumerable<GnjConclusion>> List();
    public Task<IEnumerable<GnjConclusion>> List(int limit, int page = 1);
}
