namespace StarWars.Api.Episodes.Storage
{
    public class EpisodeDBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EpisodeDBO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
