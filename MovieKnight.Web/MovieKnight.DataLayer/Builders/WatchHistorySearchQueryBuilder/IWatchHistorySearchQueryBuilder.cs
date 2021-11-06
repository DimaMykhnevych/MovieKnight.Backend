using MovieKnight.DataLayer.Models;
using System;

namespace MovieKnight.DataLayer.Builders.WatchHistorySearchQueryBuilder
{
    public interface IWatchHistorySearchQueryBuilder : IQueryBuilder<WatchHistory>
    {
        IWatchHistorySearchQueryBuilder GetWatchHistoryForUser(Guid id);
        IWatchHistorySearchQueryBuilder SetBaseWatchHistoryInfo();
        IWatchHistorySearchQueryBuilder SetHistoryWatchDate(DateTime? startDate, DateTime? endDate);
        IWatchHistorySearchQueryBuilder SetWatchHistoryMovieRating(int? fromRate, int? toRate);
    }
}
