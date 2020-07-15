using System.Collections.Generic;
using System.Linq;

namespace StarWars.Api.Characters.Storage
{
    public interface ICharacterRepository
    {
        IQueryable<CharacterDBO> GetAllCharacters();
        IQueryable<CharacterFriendDBO> GetAllCharactersFriends(IEnumerable<int> charactersIds);
    }
}
