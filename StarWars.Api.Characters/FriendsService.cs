using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Episodes
{
    public class FriendsService : IFriendsService
    {
        public Task<IGrouping<int, IEnumerable<int>>> GetAllFriendsRelations()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<int>> GetFriendsForCharacter(int id)
        {
            throw new NotImplementedException();
        }
    }
}
