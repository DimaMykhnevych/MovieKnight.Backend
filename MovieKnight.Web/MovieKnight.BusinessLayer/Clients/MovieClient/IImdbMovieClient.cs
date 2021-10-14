using MovieKnight.BusinessLayer.DTOs;
using System;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Clients.MovieClient
{
    public interface IImdbMovieClient
    {
        Task<MovieModel> GetMovieFromImdb(string movieId);
    }
}
