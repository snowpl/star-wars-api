using NServiceBus;
using StarWars.Api.Characters;
using StarWars.Api.Characters.Contracts;
using System.Threading.Tasks;

namespace StarWars.Api.BackgroundService
{
    public class CharacterCommandHandler :
            IHandleMessages<UpdateCharacterNameCommand>,
            IHandleMessages<CreateCharacterCommand>
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
    }
}
