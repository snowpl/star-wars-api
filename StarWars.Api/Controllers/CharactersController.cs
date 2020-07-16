using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using StarWars.Api.Characters;
using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Contracts.Commands;
using StarWars.Api.Infrastructure;
using StarWars.Api.SharedKernel.Contracts;

namespace StarWars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharactersService _charactersService;
        IMessageSession _messageSession;

        public CharactersController(ICharactersService charactersService,
            IMessageSession messageSession)
        {
            _charactersService = charactersService;
            _messageSession = messageSession;
        }

        [HttpGet]
        public async Task<PageResponse<Character>> Get([FromQuery] PageRequest query)
        {
            return await _charactersService.List(new GetCharactersQuery(query.PageSize, query.PageNumber));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCharacterCommand command)
        {
            await _messageSession.Send(new CreateCharacterCommand() { Planet = command.Planet, Name = command.Name }).ConfigureAwait(false);
            return Accepted();
        }

        [HttpPut]
        [Route("change-name", Name = "UpdateCharacterName")]
        public async Task<IActionResult> UpdateCharacterName([FromBody] UpdateCharacterNameCommand command)
        {
            await _messageSession.Send(new UpdateCharacterNameCommand() {Id = command.Id, Name = command.Name }).ConfigureAwait(false);
            return Accepted();
        }

        [HttpPut]
        [Route("activate", Name = "ActivateCharacterCommand")]
        public async Task<IActionResult> ActivateCharacterCommand([FromBody] ActivateCharacterCommand command)
        {
            await _messageSession.Send(new ActivateCharacterCommand() { Id = command.Id, }).ConfigureAwait(false);
            return Accepted();
        }

        [HttpDelete]
        [Route("deactivate", Name = "DeactivateCharacterCommand")]
        public async Task<IActionResult> DeactivateCharacterCommand([FromBody] DeactivateCharacterCommand command)
        {
            await _messageSession.Send(new DeactivateCharacterCommand() { Id = command.Id }).ConfigureAwait(false);
            return Accepted();
        }
    }
}
