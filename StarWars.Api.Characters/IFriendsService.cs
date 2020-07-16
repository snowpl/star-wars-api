using StarWars.Api.Characters.Contracts.Commands;
using System.Threading.Tasks;

namespace StarWars.Api.Episodes
{
    public interface IFriendsService
    {
        Task AddFriendForCharacter(AddFriendsCommand command);
        Task RemoveFriendForCharacter(RemoveFriendCommand command);
    }
}
