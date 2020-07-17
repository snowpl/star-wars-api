namespace StarWars.Api.Episodes.Models
{
    public class EpisodeDTO
    {
        public int Id { get; }
        public string Name { get; }
        public EpisodeDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
