using Microsoft.EntityFrameworkCore;
using GameStore.Models;

namespace GameStore.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        { }
        public DbSet<Game> Games { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<Library> Libraries { get; set;}
        public DbSet<Community> Communities { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Library>().ToTable("Library");
            modelBuilder.Entity<Community>().ToTable("Community");

            modelBuilder.Entity<Library>().HasKey(vf => new { vf.gameID, vf.userID });
        }
    }
}
