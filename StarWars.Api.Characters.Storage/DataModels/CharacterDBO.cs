namespace StarWars.Api.Characters.Storage
{
    public class CharacterDBO
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public string Planet { get; set; }
        public CharacterDBO(int id, string name, string planet = "")
        {
            Id = id;
            Name = name;
            Planet = planet;
        }
    }
}
