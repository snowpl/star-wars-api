namespace StarWars.Api.Episodes.Models
{
    public class EpisodeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EpisodeDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
