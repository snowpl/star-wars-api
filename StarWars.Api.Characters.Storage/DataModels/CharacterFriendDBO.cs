using StarWars.Api.Characters.Storage.DataModels;

namespace StarWars.Api.Characters.Storage
{
    public class CharacterFriendDBO
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public FriendStatusDBO FriendStatus { get; set; }
        public CharacterFriendDBO(){ }
        public CharacterFriendDBO(int id, int friendId, FriendStatusDBO status = FriendStatusDBO.Accepted)
        {
            Id = id;
            FriendId = friendId;
            FriendStatus = status;
        }
    }
}
