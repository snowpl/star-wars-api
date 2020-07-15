using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public CharactersController(ICharactersService charactersService)
        {
            _charactersService = charactersService;
        }

        [HttpGet]
        public async Task<PageResponse<Character>> Get([FromQuery] GetCharactersQuery query)
        {
            return await _charactersService.List(query);
        }

        //public async Task<PageResponse<Character>> Get(GetCharactersQuery query)
        //{
        //    return await _charactersService.List(query);
        //}
    }
}
