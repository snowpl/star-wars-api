using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Api.Episodes.Storage
{
    public interface IEpisodeRepository
    {
        IQueryable<EpisodeDBO> GetAllEpisodes();
        Task<EpisodeDBO> GetEpisode(int episodeId);
        IQueryable<EpisodeCharacterDBO> GetAllEpisodesCharacters();
        IQueryable<EpisodeCharacterDBO> GetEpisodesCharacters(int episodeId);
    }
}
