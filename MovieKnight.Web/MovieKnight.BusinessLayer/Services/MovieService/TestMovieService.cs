using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.DataLayer.Repositories.MovieRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.MovieService
{
    public class TestMovieService : IMovieService
    {
        private readonly ITestMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public TestMovieService(ITestMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public Task<MovieDto> AddMovie(AddMovieDto movieDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovie(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieModel> GetMovieFromImdb(Guid movieId)
        {
            var movie = await _movieRepository.Get(movieId);
            return _mapper.Map<MovieModel>(movie.MovieInfo);
        }

        public async Task<MovieDto> GetRecommendedMovie(string username)
        {
            return await GetFirstMovie();
        }

        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            var movies = await _movieRepository.GetAll();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        private async Task<MovieDto> GetFirstMovie()
        {
            var movie = await _movieRepository.GetFirstMovie();
            return _mapper.Map<MovieDto>(movie);
        }
    }
}
