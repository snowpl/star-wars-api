using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWars.Api.Episodes;
using StarWars.Api.Episodes.Contracts;
using StarWars.Api.Episodes.Models;

namespace StarWars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodesService _episodesService;
        public EpisodesController(IEpisodesService episodesService)
        {
            _episodesService = episodesService;
        }

        [HttpGet]
        public async Task<List<EpisodeDTO>> Get()
        {
            return await _episodesService.GetAllEpisodes().ToListAsync();
        }


        [HttpGet]
        [Route("{id}/characters")]
        public async Task<EpisodeCharacters> GetEpisodeCharacters([FromRoute] int id)
        {
            return await _episodesService.GetEpisodeCharacters(id);
        }
    }
}
