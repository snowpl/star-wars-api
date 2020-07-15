using Microsoft.EntityFrameworkCore;
using StarWars.Api.Episodes.Models;
using StarWars.Api.Episodes.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Api.Episodes
{
    public class EpisodesService : IEpisodesService
    {
        private readonly IEpisodeRepository _episodeRepository;
        public EpisodesService(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public async Task<IEnumerable<EpisodeCharacterDTO>> GetAllEpisodesCharacters(IEnumerable<int> characterIds)
        {
            return await _episodeRepository.GetAllEpisodesCharacters()
                .Where(x => characterIds.Contains(x.CharacterId))
                .Select(x => new EpisodeCharacterDTO(x.EpiosdeId, x.CharacterId))
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public IQueryable<EpisodeDTO> GetAllEpisodes()
        {
            return _episodeRepository.GetAllEpisodes().Select(x => new EpisodeDTO(x.Id, x.Name));
        }

        public async Task<IEnumerable<EpisodeDTO>> GetCharacterEpisodes(int characterId)
        {
            return await _episodeRepository.GetAllEpisodes()
                .Where(x => x.Id == characterId)
                .Select(x => new EpisodeDTO(x.Id, x.Name))
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
