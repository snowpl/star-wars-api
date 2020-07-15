using System.Linq;

namespace StarWars.Api.Episodes.Storage
{
    public interface IEpisodeRepository
    {
        IQueryable<EpisodeDBO> GetAllEpisodes();
        IQueryable<EpisodeCharacterDBO> GetAllEpisodesCharacters();
    }
}
