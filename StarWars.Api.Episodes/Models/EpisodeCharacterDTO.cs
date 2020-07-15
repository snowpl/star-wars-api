using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Api.Episodes.Models
{
    public class EpisodeCharacterDTO
    {
        public int EpiosdeId { get; set; }
        public int CharacterId { get; set; }
        public EpisodeCharacterDTO(int epiosdeId, int characterId)
        {
            EpiosdeId = epiosdeId;
            CharacterId = characterId;
        }
    }
}
