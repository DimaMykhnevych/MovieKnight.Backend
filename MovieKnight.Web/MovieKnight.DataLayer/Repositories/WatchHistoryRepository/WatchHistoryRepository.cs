using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;

namespace MovieKnight.DataLayer.Repositories.WatchHistoryRepository
{
    public class WatchHistoryRepository : Repository<WatchHistory>, IWatchHistoryRepository
    {
        public WatchHistoryRepository(MovieKnightDbContext context) : base(context)
        {
        }
    }
}
