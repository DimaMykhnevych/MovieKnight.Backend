using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.DataLayer.Builders.WatchHistorySearchQueryBuilder;
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
        private readonly IWatchHistorySearchQueryBuilder _searchQueryBuilder;
        private readonly IMapper _mapper;

        public WatchHistoryService(IWatchHistoryRepository watchHistoryRepository, IWatchHistorySearchQueryBuilder searchQueryBuilder, IMapper mapper)
        {
            _watchHistoryRepository = watchHistoryRepository;
            _searchQueryBuilder = searchQueryBuilder;
            _mapper = mapper;
        }

        public async Task<WatchHistoryDto> AddWatchHistoryItem(AddWatchHistoryDto watchHistoryDto)
        {
            var watchHistoryItem = await
                _watchHistoryRepository
                .GetWatchHistoryByUserIdAndMovie(watchHistoryDto.AppUserId, watchHistoryDto.MovieId);

            if (watchHistoryItem != null)
            {
                watchHistoryItem.Rating = watchHistoryDto.Rating;
                await _watchHistoryRepository.UpdateWatchHistoryItem(watchHistoryItem);
                return _mapper.Map<WatchHistoryDto>(watchHistoryItem);
            }

            watchHistoryItem = _mapper.Map<WatchHistory>(watchHistoryDto);
            watchHistoryItem.Id = Guid.NewGuid();
            watchHistoryItem.WatchDate = DateTime.Now;
            var added = await _watchHistoryRepository.Insert(watchHistoryItem);
            await _watchHistoryRepository.Save();
            return _mapper.Map<WatchHistoryDto>(added);
        }

        public async Task<IEnumerable<WatchHistoryDto>> GetWatchHistory(Guid currentUserId, SearchWatchHistoryDto searchParams)
        {
            var watchHistory =
                _searchQueryBuilder.SetBaseWatchHistoryInfo()
                .GetWatchHistoryForUser(currentUserId)
                .SetHistoryWatchDate(searchParams.FromDate, searchParams.ToDate)
                .SetWatchHistoryMovieRating(searchParams.FromRate, searchParams.ToRate)
                .Build()
                .ToList();

            return _mapper.Map<IEnumerable<WatchHistoryDto>>(watchHistory);
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

        public async Task<WatchHistoryStatisticsDto> GetWatchHistoryStatistics(GetWatchHistoryStatisticsDto getStatisticsDto)
        {
            List<WatchHistory> watchHistoryList = (await _watchHistoryRepository.GetWatchHistoryBetweenDates
                (getStatisticsDto.DateFrom, getStatisticsDto.DateTo)).ToList();


            WatchHistoryStatisticsDto result = new WatchHistoryStatisticsDto()
            {
                SuggestionsCount = watchHistoryList.Count,
                AverageRating = watchHistoryList.Average(wh => wh.Rating),
                UsersCount = watchHistoryList.Select(wh => wh.AppUserId).Distinct().Count(),
                MoviesCount = watchHistoryList.Select(wh => wh.MovieId).Distinct().Count()
            };

            return result;
        }
    }
}
