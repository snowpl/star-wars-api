using Microsoft.EntityFrameworkCore;

namespace StarWars.Api.Episodes.Storage
{
    public class EpisodesDbContext : DbContext
    {
        public EpisodesDbContext(DbContextOptions<EpisodesDbContext> options)
        : base(options) { }

        public DbSet<EpisodeDBO> Episodes { get; set; }
        public DbSet<EpisodeCharacterDBO> EpisodeCharacters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EpisodeCharacterDBO>()
                .HasKey(c => new { c.CharacterId, c.EpiosdeId });
        }
    }
}
