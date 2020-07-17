using StarWars.Api.Infrastructure;
using StarWars.Api.SharedKernel.Contracts;

namespace StarWars.Api.Characters.Contracts
{
    public class GetCharactersQuery : PageRequest, IQuery
    {
        public GetCharactersQuery(int pageSize, int pageNumber)
            : base(pageSize, pageNumber)
        {

        }
    }
}
