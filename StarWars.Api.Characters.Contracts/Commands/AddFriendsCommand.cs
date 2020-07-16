using NServiceBus;

namespace StarWars.Api.Characters.Contracts.Commands
{
    public class AddFriendsCommand : IMessage
    {
        public int CharacterId { get; set; }
        public int FriendId { get; set; }
    }
}
