using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using StarWars.Api.Characters;
using StarWars.Api.Characters.Contracts;
using StarWars.Api.Infrastructure;

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
        public async Task<PageResponse<Character>> Get([FromQuery] GetCharactersQuery query)
        {
            return await _charactersService.List(query);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateCharacterNameCommand command)
        {
            var message = new MyMessage();
            await _messageSession.Send(message).ConfigureAwait(false);
            await _messageSession.Send(new UpdateCharacterNameCommand() {Id = command.Id, Name = command.Name }).ConfigureAwait(false);
            return Accepted();
        }
    }
}
