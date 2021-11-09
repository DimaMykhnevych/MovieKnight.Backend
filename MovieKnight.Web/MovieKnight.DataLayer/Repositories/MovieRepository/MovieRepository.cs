using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.MovieRepository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieKnightDbContext context) : base(context)
        {
        }

        public async Task<Movie> GetFirstMovie()
        {
            return Context.Movies.First();
        }
    }
}
