using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.DataLayer.Models;
using MovieKnight.DataLayer.Repositories.WatchHistoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.WatchHistoryService
{
    public class WatchHistoryService : IWatchHistoryService
    {
        private readonly IWatchHistoryRepository _watchHistoryRepository;
        private readonly IMapper _mapper;

        public WatchHistoryService(IWatchHistoryRepository watchHistoryRepository, IMapper mapper)
        {
            _watchHistoryRepository = watchHistoryRepository;
            _mapper = mapper;
        }

        public async Task<WatchHistoryDto> AddWatchHistoryItem(AddWatchHistoryDto watchHistoryDto)
        {
            var watchHistoryItem = _mapper.Map<WatchHistory>(watchHistoryDto);
            watchHistoryItem.Id = Guid.NewGuid();
            var added = await _watchHistoryRepository.Insert(watchHistoryItem);
            await _watchHistoryRepository.Save();
            return _mapper.Map<WatchHistoryDto>(added);
        }

        public async Task<IEnumerable<WatchHistoryDto>> GetWatchHistory(Guid currentUserId)
        {
            var watchHistory = await _watchHistoryRepository.GetAll();
            var currentUserWatchHistory = watchHistory.Where(wh => wh.AppUserId == currentUserId);
            return _mapper.Map<IEnumerable<WatchHistoryDto>>(currentUserWatchHistory);
        }

        public async Task<WatchHistoryDto> GetWatchHistoryItem(Guid id)
        {
            var watchHistory = await _watchHistoryRepository.GetAll();
            var watchHistoryItem = watchHistory.ToList().FirstOrDefault(i => i.Id == id);
            return _mapper.Map<WatchHistoryDto>(watchHistoryItem);
        }

        public async Task<IEnumerable<WatchHistoryDto>> GetWatchHistoryByUserId(Guid UserId, Guid CurrentUserId)
        {
            var watchHistory = await _watchHistoryRepository.GetWatchHistoryByUserId(UserId, CurrentUserId);
            //foreach (var wh in watchHistory) wh.AppUser = null;
            return _mapper.Map<IEnumerable<WatchHistoryDto>>(watchHistory);
        }

        public async Task<bool> UpdateWatchHistoryItem(UpdateWatchHistoryDto updateWatchHistoryDto)
        {
            WatchHistory watchHistory = await _watchHistoryRepository.Get(updateWatchHistoryDto.WatchHistoryId);
            if (watchHistory == null) return false;
            watchHistory.Rating = updateWatchHistoryDto.NewRating;
            try
            {
                await _watchHistoryRepository.UpdateWatchHistoryItem(watchHistory);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
