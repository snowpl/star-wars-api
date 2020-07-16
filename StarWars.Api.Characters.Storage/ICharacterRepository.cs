using StarWars.Api.Characters.Storage.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Api.Characters.Storage
{
    public interface ICharacterRepository
    {
        IQueryable<CharacterDBO> GetAllCharacters();
        IQueryable<CharacterFriendDBO> GetAllCharactersFriends(IEnumerable<int> charactersIds);
        Task UpdateCharacterName(int id, string name);
        Task AddCharacter(string name, string planet);
        Task ChangeCharacterStatus(int id, StatusDBO status);
    }
}
