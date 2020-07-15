using StarWars.Api.Characters.Contracts;
using StarWars.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Characters
{
    public interface ICharactersService
    {
        Task<PageResponse<Character>> List(GetCharactersQuery query);
    }
}
