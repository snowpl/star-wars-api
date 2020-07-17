using FluentValidation;
using NServiceBus;

namespace StarWars.Api.Characters.Contracts
{

    public class UpdateCharacterNameCommand : IMessage
    {
        public int Id { get; }
        public string Name { get; }

        public UpdateCharacterNameCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class UpdateCharacterNameCommandValidator : AbstractValidator<UpdateCharacterNameCommand>
    {
        public UpdateCharacterNameCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(25);
        }
    }
}
