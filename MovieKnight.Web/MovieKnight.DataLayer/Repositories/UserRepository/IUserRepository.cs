using MovieKnight.DataLayer.Models;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<AppUser>
    {
        Task<AppUser> GetUserWithWatchHistory(string userName);
    }
}
