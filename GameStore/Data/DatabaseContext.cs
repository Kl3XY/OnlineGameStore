using Microsoft.EntityFrameworkCore;
using GameStore.Models;
using Humanizer;

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
        public DbSet<Comments> Comments { get; set;}
        public DbSet<Message> Messages { get; set;}
        public DbSet<Chat> Chats { get; set;}
        public DbSet<Friend> Friends { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Library>().ToTable("Library");
            modelBuilder.Entity<Community>().ToTable("Community");
            modelBuilder.Entity<Comments>().ToTable("Comments");
            modelBuilder.Entity<Message>().ToTable("Message");
            modelBuilder.Entity<Chat>().ToTable("Chat");
            modelBuilder.Entity<Friend>().ToTable("Friend");
            
            modelBuilder.Entity<Library>().HasKey(vf => new { vf.gameID, vf.userID });
            modelBuilder.Entity<Message>().HasKey(vf => new { vf.userID, vf.chatID });
            modelBuilder.Entity<Chat>().HasKey(vf => new { vf.Id});
            modelBuilder.Entity<Friend>().HasKey(vf => new { vf.userID, vf.chatID});
            modelBuilder.Entity<Community>()
                .HasMany(c => c.comments)
                    .WithOne(c => c.community)
                    .HasForeignKey(c => c.communityID)
                .HasPrincipalKey(c => c.ID);

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.User);

        }
    }
}
