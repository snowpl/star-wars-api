using Microsoft.EntityFrameworkCore;
using StarWars.Api.Characters.Storage;
using StarWars.Api.Episodes.Contracts;
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
        private readonly ICharacterRepository _characterRepository;
        public EpisodesService(IEpisodeRepository episodeRepository,
                                ICharacterRepository characterRepository)
        {
            _episodeRepository = episodeRepository;
            _characterRepository = characterRepository;
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

        public async Task<EpisodeCharacters> GetEpisodeCharacters(int episodeId)
        {
            var episode = await _episodeRepository.GetEpisode(episodeId);
            if(episode == null)
            {
                throw new KeyNotFoundException($"The episode with ${episodeId} does not exists");
            }
            var episodeCharacters = _episodeRepository.GetEpisodesCharacters(episodeId).ToList();
            var characters = _characterRepository.GetAllCharacters().Where(x => episodeCharacters.Select(a => a.CharacterId).Contains(x.Id));
            return new EpisodeCharacters(episodeId, episode.Name, characters.Select(character => character.Name));
        }
    }
}
