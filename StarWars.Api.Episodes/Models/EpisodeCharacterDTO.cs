namespace StarWars.Api.Episodes.Models
{
    public class EpisodeCharacterDTO
    {
        public int EpiosdeId { get; }
        public int CharacterId { get; }
        public EpisodeCharacterDTO(int epiosdeId, int characterId)
        {
            EpiosdeId = epiosdeId;
            CharacterId = characterId;
        }
    }
}
