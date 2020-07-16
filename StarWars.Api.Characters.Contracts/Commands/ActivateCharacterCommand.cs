using NServiceBus;

namespace StarWars.Api.Characters.Contracts.Commands
{
    public class ActivateCharacterCommand : ICommand
    {
        public int Id { get; set; }
    }
}
