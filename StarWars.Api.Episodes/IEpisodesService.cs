using StarWars.Api.Episodes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Api.Episodes
{
    public interface IEpisodesService
    {
        IQueryable<EpisodeDTO> GetAllEpisodes();
        Task<IEnumerable<EpisodeDTO>> GetCharacterEpisodes(int characterId);
        Task<IEnumerable<EpisodeCharacterDTO>> GetAllEpisodesCharacters(IEnumerable<int> characterIds);
    }
}
