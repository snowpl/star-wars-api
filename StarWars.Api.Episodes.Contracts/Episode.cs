namespace StarWars.Api.Episodes.Contracts
{
    public class Episode
    {
        public int Id { get; }
        public string Name { get; }
        public Episode(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
