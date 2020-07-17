namespace StarWars.Api.Episodes.Storage
{
    public class EpisodeCharacterDBO
    {
        public int EpiosdeId { get; private set; }
        public int CharacterId { get; private set; }
        public EpisodeCharacterDBO(int epiosdeId, int characterId)
        {
            EpiosdeId = epiosdeId;
            CharacterId = characterId;
        }
    }
}
