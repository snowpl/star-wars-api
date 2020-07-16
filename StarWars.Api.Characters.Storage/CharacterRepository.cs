using StarWars.Api.Characters.Storage.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .Where(x => x.Status == StatusDBO.Active)
                .AsQueryable();
        }

        public IQueryable<CharacterFriendDBO> GetAllCharactersFriends(IEnumerable<int> charactersIds)
        {
            return _dbContext.Friends
                .Where(x => x.FriendStatus == FriendStatusDBO.Accepted)
                .Where(x => charactersIds.Contains(x.Id));
        }

        public async Task ChangeCharacterStatus(int id, StatusDBO status)
        {
            var character = _dbContext.Characters.FirstOrDefault(x => x.Id == id);

            if (character != null)
            {
                if (character.Status != status)
                {
                    character.Status = status;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task AddCharacter(string name, string planet)
        {
            lock (_dbContext.Characters)
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
            var character = _dbContext.Characters.FirstOrDefault(x => x.Id == id);
            if (character != null)
            {
                character.Name = name;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task AddCharacterFriend(int id, int friendId)
        {
            if (BothCharactersExists(id, friendId))
            {
                if (TryGetFriends(id, friendId, out var friends))
                {
                    friends.FriendStatus = FriendStatusDBO.Accepted;
                }
                else
                {
                    _dbContext.Friends.Add(new CharacterFriendDBO(id, friendId));
                }
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveCharacterFriend(int id, int friendId)
        {
            if (BothCharactersExists(id, friendId))
            {
                if (TryGetFriends(id, friendId, out var friends))
                {
                    friends.FriendStatus = FriendStatusDBO.Removed;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private bool TryGetFriends(int id, int friendId, out CharacterFriendDBO friends)
        {
            friends = _dbContext.Friends.SingleOrDefault(x =>
                    (x.Id == id && x.FriendId == friendId)
                    || (x.FriendId == id && x.Id == friendId));
            return friends != null;
        }

        private bool BothCharactersExists(int id, int friendId)
            => _dbContext.Characters.FirstOrDefault(x => x.Id == id) != null
                && _dbContext.Characters.FirstOrDefault(x => x.Id == friendId) != null;

    }
}
