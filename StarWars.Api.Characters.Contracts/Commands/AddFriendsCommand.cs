using NServiceBus;

namespace StarWars.Api.Characters.Contracts.Commands
{
    public class AddFriendsCommand : IMessage
    {
        public int CharacterId { get; }
        public int FriendId { get; }

        public AddFriendsCommand(int characterId, int friendId)
        {
            CharacterId = characterId;
            FriendId = friendId;
        }
    }
}
