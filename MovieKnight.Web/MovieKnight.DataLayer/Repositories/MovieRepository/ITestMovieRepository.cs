using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.MovieRepository
{
    public interface ITestMovieRepository
    {
        Task<TestMovie> Get(Guid id);
        Task<TestMovie> GetFirstMovie();
        Task<IEnumerable<TestMovie>> GetAll();
    }
}
