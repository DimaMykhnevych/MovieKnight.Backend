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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
