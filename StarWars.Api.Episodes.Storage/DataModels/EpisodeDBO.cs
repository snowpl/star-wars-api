namespace StarWars.Api.Episodes.Storage
{
    public class EpisodeDBO
    {
        public int Id { get; }
        public string Name { get; }
        public EpisodeDBO() { }
        public EpisodeDBO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
