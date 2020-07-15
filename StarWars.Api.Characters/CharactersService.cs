using Microsoft.EntityFrameworkCore;
using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Mappers;
using StarWars.Api.Characters.Models;
using StarWars.Api.Characters.Storage;
using StarWars.Api.Episodes;
using StarWars.Api.Infrastructure;
using StarWars.Api.Infrastructure.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Api.Characters
{
    public class CharactersService : ICharactersService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IEpisodesService _episodesService;
        public CharactersService(ICharacterRepository characterRepository,
            IEpisodesService episodesService)
        {
            _characterRepository = characterRepository;
            _episodesService = episodesService;
        }

        public async Task<PageResponse<Character>> List(GetCharactersQuery query)
        {
            var charactersTask = _characterRepository.GetAllCharacters()
                .Select(x => new CharacterDTO(x.Id, x.Name, x.Planet))
                .PickPage(query);

            var episodesTask = _episodesService.GetAllEpisodes().ToListAsync();

            await Task.WhenAll(charactersTask, episodesTask);
            var characters = charactersTask.Result;

            var charactersIds = characters.Results.Select(x => x.Id);

            var episodeCharactersTask = _episodesService.GetAllEpisodesCharacters(charactersIds);
            var friendsTasks = _characterRepository.GetAllCharactersFriends(charactersIds)
                .Select(x => new CharacterFriendDTO(x.Id, x.FriendId))
                .ToListAsync();

            await Task.WhenAll(episodeCharactersTask, friendsTasks);

            return characters.ComposeCharacters(episodesTask.Result, friendsTasks.Result, episodeCharactersTask.Result);
        }
    }
}
