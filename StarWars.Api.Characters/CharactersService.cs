using Microsoft.EntityFrameworkCore;
using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Contracts.Commands;
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
            var characters = await _characterRepository.GetAllCharacters()
                .Select(x => new CharacterDTO(x.Id, x.Name, x.Planet))
                .PickPage(query);

            var episodes= _episodesService.GetAllEpisodes().ToList();
            var charactersIds = characters.Results.Select(x => x.Id);

            var episodeCharactersTask = _episodesService.GetAllEpisodesCharacters(charactersIds);
            var friendsTasks = Task.FromResult(_characterRepository.GetAllCharactersFriends(charactersIds)
                .Select(x => new CharacterFriendDTO(x.Id, x.FriendId))
                .ToList());

            await Task.WhenAll(episodeCharactersTask, friendsTasks);

            return characters.ComposeCharacters(episodes, friendsTasks.Result, episodeCharactersTask.Result);
        }
        public Task UpdateCharacterName(UpdateCharacterNameCommand command)
            => _characterRepository.UpdateCharacterName(command.Id, command.Name);

        public Task AddCharacter(CreateCharacterCommand command)
            =>  _characterRepository.AddCharacter(command.Name, command.Planet);

        public Task DeactivateCharacter(DeactivateCharacterCommand command)
            => _characterRepository.ChangeCharacterStatus(command.Id, Storage.DataModels.StatusDBO.Deactivated);

        public Task ActivateCharacter(ActivateCharacterCommand command)
            => _characterRepository.ChangeCharacterStatus(command.Id, Storage.DataModels.StatusDBO.Active);
    }
}
