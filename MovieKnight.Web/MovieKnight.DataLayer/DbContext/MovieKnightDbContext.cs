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
            base.OnModelCreating(builder);

            builder.Entity<Friends>()
                .HasOne(a => a.AppUser1)
                .WithMany(b => b.Friends1)
                .HasForeignKey(c => c.AppUser1Id);

            builder.Entity<Friends>()
                .HasOne(a => a.AppUser2)
                .WithMany(b => b.Friends2)
                .HasForeignKey(c => c.AppUser2Id).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<FriendRequest>()
                .HasOne(a => a.Sender)
                .WithMany(b => b.FriendsRequestsSent)
                .HasForeignKey(c => c.SenderId);

            builder.Entity<FriendRequest>()
                .HasOne(a => a.Receiver)
                .WithMany(b => b.FriendsRequestsReceived)
                .HasForeignKey(c => c.ReceiverId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
