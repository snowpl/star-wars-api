using NServiceBus;
using NServiceBus.Logging;
using StarWars.Api.Characters;
using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Storage;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.BackgroundService
{
    public class UpdateCharacterNameCommandHandler :
            IHandleMessages<UpdateCharacterNameCommand>
    {
        private readonly ICharactersService _charactersService;
        public UpdateCharacterNameCommandHandler(ICharactersService charactersService)
        {
            _charactersService = charactersService;
        }
        public Task Handle(UpdateCharacterNameCommand message, IMessageHandlerContext context)
        {
            _charactersService.List(new GetCharactersQuery(5, 1));
            return Task.CompletedTask;
        }
    }
}
