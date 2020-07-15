using System.Linq;

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
    }
}
