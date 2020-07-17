using NServiceBus;

namespace StarWars.Api.Characters.Contracts
{
    public class CreateCharacterCommand : IMessage
    {
        public string Name { get; }
        public string Planet { get; }
        public CreateCharacterCommand(string name, string planet)
        {
            Name = name;
            Planet = planet;
        }
    }
}
