﻿using MovieKnight.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.WatchHistoryService
{
    public interface IWatchHistoryService
    {
        Task<IEnumerable<WatchHistoryDto>> GetWatchHistory();
        Task<WatchHistoryDto> GetWatchHistoryItem(Guid id);
        Task<WatchHistoryDto> AddWatchHistoryItem(AddWatchHistoryDto watchHistoryDto);
    }
}
