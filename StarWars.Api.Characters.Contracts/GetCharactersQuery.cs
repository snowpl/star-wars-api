using StarWars.Api.SharedKernel.Contracts;

namespace StarWars.Api.Characters.Contracts
{
    public class GetCharactersQuery : PageRequest
    {
        public GetCharactersQuery(int pageSize, int pageNumber)
            : base(pageSize, pageNumber)
        {

        }
    }
}
