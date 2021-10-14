using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Services.MovieService;
using MovieKnight.DataLayer.Models;

namespace MovieKnight.BusinessLayer.Resolvers
{
    public class WatchHistoryMovieResolver : IValueResolver<WatchHistory, WatchHistoryDto, MovieModel>
    {
        private readonly IMovieService _movieService;

        public WatchHistoryMovieResolver(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public MovieModel Resolve(WatchHistory source, WatchHistoryDto destination, MovieModel destMember, ResolutionContext context)
        {
            return _movieService.GetMovieFromImdb(source.MovieId).Result;
        }
    }
}
