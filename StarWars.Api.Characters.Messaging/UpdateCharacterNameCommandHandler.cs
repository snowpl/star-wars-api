//using NServiceBus;
//using NServiceBus.Logging;
//using StarWars.Api.Characters.Contracts;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace StarWars.Api.Characters.Messaging
//{
//    public class UpdateCharacterNameCommandHandler :
//        IUpdateCharacterNameCommandHandler
//    {
//        private readonly ICharactersService _charactersService;
//        public UpdateCharacterNameCommandHandler(ICharactersService charactersService)
//        {
//            _charactersService = charactersService;
//        }

//        static ILog log = LogManager.GetLogger<UpdateCharacterNameCommandHandler>();
//        public Task Handle(UpdateCharacterNameCommand message, IMessageHandlerContext context)
//        {
//            log.Info($"handling message for id: {message.Id} and name: {message.Name}");
//            return Task.CompletedTask;
//        }

//        public Task Handle(MyMessage message, IMessageHandlerContext context)
//        {
//            log.Info($"Got message");
//            return Task.CompletedTask;
//        }
//    }
//}
