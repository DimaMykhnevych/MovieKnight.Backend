using Microsoft.EntityFrameworkCore;
using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.UserRepository
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(MovieKnightDbContext context) : base(context)
        {
        }

        public async Task<AppUser> GetUserWithWatchHistory(string userName)
        {
            return await Context.AppUsers
                 .Include(u => u.WatchHistory)
                 .ThenInclude(u => u.Movie)
                 .Include(u => u.Friends)
                 .FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}
