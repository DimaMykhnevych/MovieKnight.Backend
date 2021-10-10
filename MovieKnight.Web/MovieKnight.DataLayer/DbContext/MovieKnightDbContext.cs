using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieKnight.DataLayer.Models;

namespace MovieKnight.DataLayer.DbContext
{
    public class MovieKnightDbContext : IdentityDbContext<AppUser, UserRole, int>
    {
        public MovieKnightDbContext(DbContextOptions<MovieKnightDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
