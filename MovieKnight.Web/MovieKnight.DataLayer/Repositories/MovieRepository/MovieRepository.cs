using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;

namespace MovieKnight.DataLayer.Repositories.MovieRepository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieKnightDbContext context) : base(context)
        {
        }
    }
}
