using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.WatchHistoryRepository
{
    public interface IWatchHistoryRepository : IRepository<WatchHistory>
    {
        Task<IEnumerable<WatchHistory>> GetWatchHistoryByUserId(Guid userId, Guid currentUserId);
        Task<WatchHistory> GetWatchHistoryByUserIdAndMovie(Guid userId, Guid movieId);
        Task UpdateWatchHistoryItem(WatchHistory movie);
        Task<IEnumerable<WatchHistory>> GetWatchHistoryBetweenDates(DateTime startDate, DateTime endDate);
    }
}
