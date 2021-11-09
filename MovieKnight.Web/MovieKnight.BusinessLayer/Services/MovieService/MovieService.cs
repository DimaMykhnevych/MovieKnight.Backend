using AutoMapper;
using MovieKnight.BusinessLayer.Clients.MovieClient;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.DataLayer.Models;
using MovieKnight.DataLayer.Repositories.MovieRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly IImdbMovieClient _imdbMovieClient;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, IImdbMovieClient imdbMovieClient)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _imdbMovieClient = imdbMovieClient;
        }

        public async Task<IEnumerable<MovieDto>> GetMovies()
        {
            IEnumerable<Movie> movies = await _movieRepository.GetAll();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public async Task<MovieDto> AddMovie(AddMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            movie.Id = Guid.NewGuid();
            var added = await _movieRepository.Insert(movie);
            await _movieRepository.Save();
            return _mapper.Map<MovieDto>(added);
        }

        public async Task<bool> DeleteMovie(Guid id)
        {
            var movieToDelete = await _movieRepository.Get(id);
            if (movieToDelete == null)
                return false;
             _movieRepository.Delete(movieToDelete);
            await _movieRepository.Save();
            return true;
        }

        public async Task<MovieModel> GetMovieFromImdb(Guid movieId)
        {
            var movie = await _movieRepository.Get(movieId);
            var result = await _imdbMovieClient.GetMovieFromImdb(movie.IMDbId);
            return result;
        }

        public async Task<MovieDto> GetFirstMovie()
        {
            var movie = await _movieRepository.GetFirstMovie();
            return _mapper.Map<MovieDto>(movie);
        }
    }
}
