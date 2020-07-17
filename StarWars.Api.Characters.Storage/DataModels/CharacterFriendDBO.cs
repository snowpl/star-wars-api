using StarWars.Api.Characters.Storage.DataModels;

namespace StarWars.Api.Characters.Storage
{
    public class CharacterFriendDBO
    {
        public int Id { get; private set; }
        public int FriendId { get; private set; }
        public FriendStatusDBO FriendStatus { get; private set; }
        public CharacterFriendDBO(){ }
        public CharacterFriendDBO(int id, int friendId, FriendStatusDBO status = FriendStatusDBO.Accepted)
        {
            Id = id;
            FriendId = friendId;
            FriendStatus = status;
        }

        internal void SetStatus(FriendStatusDBO status)
        {
            FriendStatus = status;
        }
    }
}
