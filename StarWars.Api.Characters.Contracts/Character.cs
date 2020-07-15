using System.Collections.Generic;

namespace StarWars.Api.Characters.Contracts
{
    public class Character
    {
        public int Id { get; }
        public string Name { get; }
        public IEnumerable<string> EpisodesNames { get; }
        public IEnumerable<int> FriendsIds { get; }
        public string Planet { get; }
        public Character(int id, string name, IEnumerable<string> episodesNames, IEnumerable<int> friendsIds, string planet = "")
        {
            Id = id;
            Name = name;
            EpisodesNames = episodesNames;
            FriendsIds = friendsIds;
            Planet = planet;
        }
    }
}
