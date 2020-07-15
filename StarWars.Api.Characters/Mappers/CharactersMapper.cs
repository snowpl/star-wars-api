using StarWars.Api.Characters.Contracts;
using StarWars.Api.Characters.Models;
using StarWars.Api.Episodes.Models;
using StarWars.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace StarWars.Api.Characters.Mappers
{
    public static class CharactersMapper
    {
        public static PageResponse<Character> ComposeCharacters(this PageResponse<CharacterDTO> input,
            List<EpisodeDTO> episodes, List<CharacterFriendDTO> characterFriends, IEnumerable<EpisodeCharacterDTO> episodeCharacters)
        {
            return new PageResponse<Character>(
                pagingInfo: input.PagingInfo,
                results: input.Results.Select(character =>
                    new Character(character.Id,
                                  character.Name,
                                  GetEpisodesNames(episodes, episodeCharacters, character),
                                  GetCharacterFriends(characterFriends, character),
                                  character.Planet)).ToImmutableList()
                );
        }

        private static IEnumerable<int> GetCharacterFriends(List<CharacterFriendDTO> characterFriends, CharacterDTO character) 
            => characterFriends
                .Where(x => character.Id == x.Id)
                .Select(x => x.FriendId)
                .Union(characterFriends.Where(x => x.FriendId == character.Id)
                .Select(x => x.Id));

        private static IEnumerable<string> GetEpisodesNames(List<EpisodeDTO> episodes, IEnumerable<EpisodeCharacterDTO> episodeCharacters, CharacterDTO character)
            => episodes.Where(episodeInfo =>
                    episodeCharacters
                    .Where(episode => character.Id == episode.CharacterId)
                    .Select(x => x.EpiosdeId)
                    .Contains(episodeInfo.Id))
                    .Select(x => x.Name);
    }
}
