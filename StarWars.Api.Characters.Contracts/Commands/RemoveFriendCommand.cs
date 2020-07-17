using NServiceBus;

namespace StarWars.Api.Characters.Contracts.Commands
{
    public class RemoveFriendCommand : IMessage
    {
        public int CharacterId { get; }
        public int FriendId { get; }

        public RemoveFriendCommand(int characterId, int friendId)
        {
            CharacterId = characterId;
            FriendId = friendId;
        }
    }
}
