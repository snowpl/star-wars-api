namespace StarWars.Api.Episodes.Storage
{
    public class EpisodeCharacterDBO
    {
        public int EpiosdeId { get; }
        public int CharacterId { get; }
        public EpisodeCharacterDBO() { }
        public EpisodeCharacterDBO(int epiosdeId, int characterId)
        {
            EpiosdeId = epiosdeId;
            CharacterId = characterId;
        }
    }
}
