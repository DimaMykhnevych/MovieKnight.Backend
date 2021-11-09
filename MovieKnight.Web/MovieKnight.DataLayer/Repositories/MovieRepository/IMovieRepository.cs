using MovieKnight.DataLayer.Models;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.MovieRepository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<Movie> GetFirstMovie();
    }
}
