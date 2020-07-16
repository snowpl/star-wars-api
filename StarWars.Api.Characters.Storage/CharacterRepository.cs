using StarWars.Api.Characters.Storage.DataModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

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
            return _dbContext.Characters
                .Where(x => x.Status == DataModels.StatusDBO.Active)
                .AsQueryable();
        }

        public IQueryable<CharacterFriendDBO> GetAllCharactersFriends(IEnumerable<int> charactersIds)
        {
            return _dbContext.Friends
                .Where(x => charactersIds.Contains(x.Id));
        }

        public async Task ChangeCharacterStatus(int id, StatusDBO status)
        {
            var character = _dbContext.Characters.Find(id);
            
            if(character != null)
            {
                if(character.Status != status)
                {
                    character.Status = status;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task AddCharacter(string name, string planet)
        {
            lock(_dbContext.Characters)
            {
                var maxId = _dbContext.Characters.Max(x => x.Id);
                {
                    _dbContext.Characters.Add(new CharacterDBO(++maxId, name, planet));
                }
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCharacterName(int id, string name)
        {
            var character = _dbContext.Characters.Find(id);
            if(character != null)
            {
                character.Name = name;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
