using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Api.Characters.Storage;
using StarWars.Api.Episodes.Storage;
using System;
using System.Linq;
using CharacterDBO = StarWars.Api.Characters.Storage.CharacterDBO;

namespace StarWars.Api
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CharactersDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<CharactersDbContext>>()))
            {

                if (context.Characters.Any())
                {
                    return;
                }

                context.Characters.AddRange(
                    new CharacterDBO(1, "Luke Skywalker"),
                    new CharacterDBO(2, "Dark Vader"),
                    new CharacterDBO(3, "Han Solo"),
                    new CharacterDBO(4, "Leia Organa", "Alderaan"),
                    new CharacterDBO(5, "Wilhuff Tarkin"),
                    new CharacterDBO(6, "C-3PO"),
                    new CharacterDBO(7, "R2-D2")
                );

                context.Friends.AddRange(
                    new CharacterFriendDBO(1, 3),
                    new CharacterFriendDBO(1, 4),
                    new CharacterFriendDBO(1, 6),
                    new CharacterFriendDBO(1, 7),
                    new CharacterFriendDBO(2, 5),
                    new CharacterFriendDBO(3, 4),
                    new CharacterFriendDBO(3, 7),
                    new CharacterFriendDBO(4, 6),
                    new CharacterFriendDBO(4, 7),
                    new CharacterFriendDBO(6, 7)
                    );
                context.SaveChanges();
            }

            using(var episodeContext = new EpisodesDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<EpisodesDbContext>>()))
            {
                if (episodeContext.Episodes.Any())
                {
                    return;
                }

                episodeContext.Episodes.AddRange(
                    new EpisodeDBO(4, "NEWHOPE"),
                    new EpisodeDBO(5, "EMPIRE"),
                    new EpisodeDBO(6, "JEDI")
                    );

                episodeContext.EpisodeCharacters.AddRange(
                    new EpisodeCharacterDBO(4, 1),
                    new EpisodeCharacterDBO(5, 1),
                    new EpisodeCharacterDBO(6, 1),
                    new EpisodeCharacterDBO(4, 2),
                    new EpisodeCharacterDBO(5, 2),
                    new EpisodeCharacterDBO(6, 2),
                    new EpisodeCharacterDBO(4, 3),
                    new EpisodeCharacterDBO(5, 3),
                    new EpisodeCharacterDBO(6, 3),
                    new EpisodeCharacterDBO(4, 4),
                    new EpisodeCharacterDBO(5, 4),
                    new EpisodeCharacterDBO(6, 4),
                    new EpisodeCharacterDBO(4, 6),
                    new EpisodeCharacterDBO(5, 6),
                    new EpisodeCharacterDBO(6, 6),
                    new EpisodeCharacterDBO(4, 7),
                    new EpisodeCharacterDBO(5, 7),
                    new EpisodeCharacterDBO(6, 7),
                    new EpisodeCharacterDBO(5, 5)
                    );

                episodeContext.SaveChanges();
            }
        }
    }
}
