using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Contracts.Commands;
using StarWars.Api.Infrastructure;
using System.Threading.Tasks;

namespace StarWars.Api.Characters
{
    public interface ICharactersService
    {
        Task<PageResponse<Character>> List(GetCharactersQuery query);
        Task UpdateCharacterName(UpdateCharacterNameCommand command);
        Task AddCharacter(CreateCharacterCommand command);
        Task ActivateCharacter(ActivateCharacterCommand command);
        Task DeactivateCharacter(DeactivateCharacterCommand command);
    }
}
