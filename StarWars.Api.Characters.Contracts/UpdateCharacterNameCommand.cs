using FluentValidation;
using NServiceBus;

namespace StarWars.Api.Characters.Contracts
{
    public class MyMessage : ICommand
    {

    }

    public class UpdateCharacterNameCommand : IMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
