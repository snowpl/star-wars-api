namespace StarWars.Api.Characters.Models
{
    public class CharacterFriendDTO
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public CharacterFriendDTO(int id, int friendId)
        {
            Id = id;
            FriendId = friendId;
        }
    }
}
