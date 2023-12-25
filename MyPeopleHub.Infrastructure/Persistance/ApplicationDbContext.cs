using Microsoft.EntityFrameworkCore;
using MyPeopleHub.Domain.Entities;

namespace MyPeopleHub.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Friendship>()
                .HasKey(x => new { x.FriendId, x.UserId });

            modelBuilder.Entity<Friendship>()
                .HasOne(x => x.User)
                .WithMany(x => x.Friendships)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Friendship>()
                .HasOne(x => x.Friend)
                .WithMany()
                .HasForeignKey(x => x.FriendId);
        }
    }
}
