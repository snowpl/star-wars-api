using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Api.Episodes
{
    public interface IFriendsService
    {
        Task<IEnumerable<int>> GetFriendsForCharacter(int id);
        Task<IGrouping<int, IEnumerable<int>>> GetAllFriendsRelations();
    }
}
