using Microsoft.EntityFrameworkCore;

namespace StarWars.Api.Characters.Storage
{
    public class CharactersDbContext : DbContext
    {
        public CharactersDbContext(DbContextOptions<CharactersDbContext> options)
        : base(options) { }

        public DbSet<CharacterDBO> Characters { get; set; }
        public DbSet<CharacterFriendDBO> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterFriendDBO>()
                .HasKey(c => new { c.Id, c.FriendId });

            modelBuilder.Entity<CharacterFriendDBO>()
                .Property(x => x.FriendStatus)
                .HasConversion(typeof(short));
        }
    }
}
