using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;

namespace MovieKnight.DataLayer.Repositories.UserRepository
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(MovieKnightDbContext context) : base(context)
        {
        }
    }
}
