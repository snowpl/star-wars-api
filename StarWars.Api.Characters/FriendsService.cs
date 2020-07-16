using StarWars.Api.Characters.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Episodes
{
    public class FriendsService : IFriendsService
    {
        private readonly ICharacterRepository _characterRepository;
        public FriendsService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public Task AddFriendForCharacter(int characterId, int friendId)
        {
            _characterRepository.
        }
    }
}
