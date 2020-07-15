namespace StarWars.Api.Characters.Storage
{
    public class CharacterFriendDBO
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public CharacterFriendDBO(int id, int friendId)
        {
            Id = id;
            FriendId = friendId;
        }
    }
}
