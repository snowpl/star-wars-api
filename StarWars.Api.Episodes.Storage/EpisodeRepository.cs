using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Api.Episodes.Storage
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly EpisodesDbContext _dbContext;
        public EpisodeRepository(EpisodesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<EpisodeDBO> GetAllEpisodes()
        {
            return _dbContext.Episodes.AsQueryable();
        }

        public IQueryable<EpisodeCharacterDBO> GetAllEpisodesCharacters()
        {
            return _dbContext.EpisodeCharacters.AsQueryable();
        }

        public async Task<EpisodeDBO> GetEpisode(int episodeId) 
            => await _dbContext.Episodes.FirstOrDefaultAsync(x => x.Id == episodeId);

        public IQueryable<EpisodeCharacterDBO> GetEpisodesCharacters(int episodeId)
            => _dbContext.EpisodeCharacters.Where(x => x.EpiosdeId == episodeId);
    }
}
