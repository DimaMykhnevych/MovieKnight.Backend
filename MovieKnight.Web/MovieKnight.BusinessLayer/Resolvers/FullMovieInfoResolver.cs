using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Services.MovieService;
using MovieKnight.DataLayer.Models;

namespace MovieKnight.BusinessLayer.Resolvers
{
    public class FullMovieInfoResolver : IValueResolver<Movie, MovieDto, MovieModel>
    {
        private readonly IMovieService _movieService;

        public FullMovieInfoResolver(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public MovieModel Resolve(Movie source, MovieDto destination, MovieModel destMember, ResolutionContext context)
        {
            return _movieService.GetMovieFromImdb(source.Id).Result;
        }
    }
}
