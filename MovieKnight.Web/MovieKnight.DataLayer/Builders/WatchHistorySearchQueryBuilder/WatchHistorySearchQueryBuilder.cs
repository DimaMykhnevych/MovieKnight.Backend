using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;
using System;
using System.Linq;

namespace MovieKnight.DataLayer.Builders.WatchHistorySearchQueryBuilder
{
    public class WatchHistorySearchQueryBuilder : IWatchHistorySearchQueryBuilder
    {
        private readonly MovieKnightDbContext _dbContext;
        private IQueryable<WatchHistory> _query;

        public WatchHistorySearchQueryBuilder(MovieKnightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<WatchHistory> Build()
        {
            IQueryable<WatchHistory> result = _query;
            _query = null;
            return result;
        }

        public IWatchHistorySearchQueryBuilder SetBaseWatchHistoryInfo()
        {
            _query = _dbContext.WatchHistory;
            return this;
        }

        public IWatchHistorySearchQueryBuilder GetWatchHistoryForUser(Guid id)
        {
            _query = _query.Where(w => w.AppUserId == id);
            return this;
        }

        public IWatchHistorySearchQueryBuilder SetHistoryWatchDate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null && endDate != null)
            {
                _query = _query.Where(tp => tp.WatchDate <= endDate);
            }
            else if (endDate == null && startDate != null)
            {
                _query = _query.Where(tp => tp.WatchDate >= startDate);
            }
            else if (startDate != null && endDate != null)
            {
                _query = _query.Where(tp => tp.WatchDate >= startDate
                && tp.WatchDate <= endDate);
            }
            return this;
        }

        public IWatchHistorySearchQueryBuilder SetWatchHistoryMovieRating(int? fromRate, int? toRate)
        {
            if (fromRate == null && toRate != null)
            {
                _query = _query.Where(j => j.Rating <= toRate);
            }
            else if (toRate == null && fromRate != null)
            {
                _query = _query.Where(j => j.Rating >= fromRate);
            }
            else if (fromRate != null && toRate != null)
            {
                _query = _query.Where(j => j.Rating >= fromRate
               && j.Rating <= toRate);
            }
            return this;
        }
    }
}
