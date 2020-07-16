using StarWars.Api.Characters.Contracts.Commands;
using StarWars.Api.Characters.Storage;
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

        public Task AddFriendForCharacter(AddFriendsCommand command) 
            => _characterRepository.AddCharacterFriend(command.CharacterId, command.FriendId);

        public Task RemoveFriendForCharacter(RemoveFriendCommand command) 
            => _characterRepository.RemoveCharacterFriend(command.CharacterId, command.FriendId);
    }
}
