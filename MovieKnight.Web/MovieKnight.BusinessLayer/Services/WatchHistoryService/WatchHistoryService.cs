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

        public async Task<IEnumerable<WatchHistoryDto>> GetWatchHistory()
        {
            var watchHistory = await _watchHistoryRepository.GetAll();
            return _mapper.Map<IEnumerable<WatchHistoryDto>>(watchHistory);
        }

        public async Task<WatchHistoryDto> GetWatchHistoryItem(Guid id)
        {
            var watchHistory = await _watchHistoryRepository.GetAll();
            var watchHistoryItem = watchHistory.ToList().FirstOrDefault(i => i.Id == id);
            return _mapper.Map<WatchHistoryDto>(watchHistoryItem);
        }
    }
}
