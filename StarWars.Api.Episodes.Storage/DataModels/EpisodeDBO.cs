namespace StarWars.Api.Episodes.Storage
{
    public class EpisodeDBO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public EpisodeDBO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
