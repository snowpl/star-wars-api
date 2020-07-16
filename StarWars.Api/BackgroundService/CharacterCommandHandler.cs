using NServiceBus;
using StarWars.Api.Characters;
using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Contracts.Commands;
using System.Threading.Tasks;

namespace StarWars.Api.BackgroundService
{
    public class CharacterCommandHandler :
            IHandleMessages<UpdateCharacterNameCommand>,
            IHandleMessages<CreateCharacterCommand>,
            IHandleMessages<ActivateCharacterCommand>,
            IHandleMessages<DeactivateCharacterCommand>
    {
        private readonly ICharactersService _charactersService;
        public CharacterCommandHandler(ICharactersService charactersService)
        {
            _charactersService = charactersService;
        }

        public Task Handle(UpdateCharacterNameCommand message, IMessageHandlerContext context)
            => Task.FromResult(_charactersService.UpdateCharacterName(message));

        public Task Handle(CreateCharacterCommand message, IMessageHandlerContext context) 
            => Task.FromResult(_charactersService.AddCharacter(message));

        public Task Handle(ActivateCharacterCommand message, IMessageHandlerContext context)
            => Task.FromResult(_charactersService.ActivateCharacter(message));

        public Task Handle(DeactivateCharacterCommand message, IMessageHandlerContext context)
            => Task.FromResult(_charactersService.DeactivateCharacter(message));
    }
}
