using MovieKnight.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.MovieService
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMovies();
        Task<MovieDto> GetRecommendedMovie(string username);
        Task<MovieModel> GetMovieFromImdb(Guid movieId);
        Task<MovieDto> AddMovie(AddMovieDto movieDto);
        Task<bool> DeleteMovie(Guid id);
    }
}
