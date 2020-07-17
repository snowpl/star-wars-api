using NServiceBus;

namespace StarWars.Api.Characters.Contracts.Commands
{
    public class DeactivateCharacterCommand : IMessage
    {
        public int Id { get; }
        public DeactivateCharacterCommand(int id)
        {
            Id = id;
        }
    }
}
