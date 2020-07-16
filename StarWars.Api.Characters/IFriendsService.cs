using System.Threading.Tasks;

namespace StarWars.Api.Episodes
{
    public interface IFriendsService
    {
        Task AddFriendForCharacter(int characterId, int friendId);
    }
}
