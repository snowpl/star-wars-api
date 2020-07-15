namespace StarWars.Api.Episodes.Storage
{
    public class EpisodeCharacterDBO
    {
        public int EpiosdeId { get; set; }
        public int CharacterId { get; set; }
        public EpisodeCharacterDBO(int epiosdeId, int characterId)
        {
            EpiosdeId = epiosdeId;
            CharacterId = characterId;
        }
    }
}
