using NServiceBus;

namespace StarWars.Api.Characters.Contracts
{
    public class CreateCharacterCommand : IMessage
    {
        public string Name { get; set; }
        public string Planet { get; set; }
    }
}
