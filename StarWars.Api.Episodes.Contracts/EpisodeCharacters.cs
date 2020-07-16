using System.Collections.Generic;

namespace StarWars.Api.Episodes.Contracts
{
    public class EpisodeCharacters
    {
        public int EpisodeId { get; }
        public string Name { get; }
        public IEnumerable<string> CharacterNames { get; }
        public EpisodeCharacters(int episodeId, string name, IEnumerable<string> characterNames)
        {
            EpisodeId = episodeId;
            Name = name;
            CharacterNames = characterNames;
        }
    }
}
