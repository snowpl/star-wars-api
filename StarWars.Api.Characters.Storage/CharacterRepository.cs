using System.Collections.Generic;
using System.Linq;

namespace StarWars.Api.Characters.Storage
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly CharactersDbContext _dbContext;
        public CharacterRepository(CharactersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<CharacterDBO> GetAllCharacters()
        {
            return _dbContext.Characters.AsQueryable();
        }

        public IQueryable<CharacterFriendDBO> GetAllCharactersFriends(IEnumerable<int> charactersIds)
        {
            return _dbContext.Friends.Where(x => charactersIds.Contains(x.Id));
        }
    }
}
