using MovieKnight.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.WatchHistoryService
{
    public interface IWatchHistoryService
    {
        Task<IEnumerable<WatchHistoryDto>> GetWatchHistory(Guid currentUserId, SearchWatchHistoryDto searchParams);
        Task<WatchHistoryDto> GetWatchHistoryItem(Guid id);
        Task<IEnumerable<WatchHistoryDto>> GetWatchHistoryByUserId(Guid UserId, Guid CurrentUserId);
        Task<WatchHistoryDto> AddWatchHistoryItem(AddWatchHistoryDto watchHistoryDto);
        Task<bool> UpdateWatchHistoryItem(UpdateWatchHistoryDto updateWatchHistoryDto);
    }
}
