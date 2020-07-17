namespace StarWars.Api.Characters.Models
{
    public class CharacterFriendDTO
    {
        public int Id { get; }
        public int FriendId { get; }
        public CharacterFriendDTO(int id, int friendId)
        {
            Id = id;
            FriendId = friendId;
        }
    }
}
