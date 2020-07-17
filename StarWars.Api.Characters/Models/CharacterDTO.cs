namespace StarWars.Api.Characters.Models
{
    public class CharacterDTO
    {
        public int Id { get; }
        public string Name { get; }
        public string Planet { get; }
        public CharacterDTO(int id, string name, string planet = "")
        {
            Id = id;
            Name = name;
            Planet = planet;
        }
    }
}
