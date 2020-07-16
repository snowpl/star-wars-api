using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using StarWars.Api.Characters.Contracts.Commands;

namespace StarWars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        IMessageSession _messageSession;

        public FriendsController(IMessageSession messageSession)
        {
            _messageSession = messageSession;
        }

        [HttpPost]
        [Route("add", Name = "AddFriendsCommand")]
        public async Task<IActionResult> Add([FromBody] AddFriendsCommand command)
        {
            await _messageSession.Send(command).ConfigureAwait(false);
            return Accepted();
        }

        [HttpDelete]
        [Route("remove", Name = "Remove")]
        public async Task<IActionResult> Remove([FromBody] RemoveFriendCommand command)
        {
            await _messageSession.Send(command).ConfigureAwait(false);
            return Accepted();
        }
    }
}
