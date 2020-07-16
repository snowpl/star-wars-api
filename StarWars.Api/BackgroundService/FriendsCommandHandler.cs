using NServiceBus;
using StarWars.Api.Characters.Contracts.Commands;
using StarWars.Api.Episodes;
using System.Threading.Tasks;

namespace StarWars.Api.BackgroundService
{
    public class FriendsCommandHandler
        : IHandleMessages<AddFriendsCommand>,
          IHandleMessages<RemoveFriendCommand>
    {
        private readonly IFriendsService _friendsService;
        public FriendsCommandHandler(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        public Task Handle(AddFriendsCommand message, IMessageHandlerContext context)
            => Task.FromResult(_friendsService.AddFriendForCharacter(message));

        public Task Handle(RemoveFriendCommand message, IMessageHandlerContext context)
            => Task.FromResult(_friendsService.RemoveFriendForCharacter(message));
    }
}
