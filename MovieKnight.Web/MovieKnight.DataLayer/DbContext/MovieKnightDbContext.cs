using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieKnight.DataLayer.Models;
using System;

namespace MovieKnight.DataLayer.DbContext
{
    public class MovieKnightDbContext : IdentityDbContext<AppUser, UserRole, Guid>
    {
        public MovieKnightDbContext(DbContextOptions<MovieKnightDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<WatchHistory> WatchHistory { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Friends> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // FriendRequest entity configuration
            builder.Entity<FriendRequest>().HasOne(r => r.Receiver)
                     .WithMany(r => r.FriendRequests).HasForeignKey(r => r.ReceiverId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<FriendRequest>().HasOne(r => r.Sender)
                                        .WithMany().HasForeignKey(r => r.SenderId).OnDelete(DeleteBehavior.NoAction); 

            builder.Entity<FriendRequest>().HasKey(r => new { r.ReceiverId, r.SenderId });

            // Friends entity configuration
            builder.Entity<Friends>().HasOne(f => f.Friend1)
                     .WithMany(f => f.Friends).HasForeignKey(f => f.Friend1Id).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Friends>().HasOne(f => f.Friend2)
                     .WithMany().HasForeignKey(f => f.Friend2Id).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Friends>().HasKey(f => new { f.Friend1Id, f.Friend2Id });

            base.OnModelCreating(builder);
        }
    }
}
