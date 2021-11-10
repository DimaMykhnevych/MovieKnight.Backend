using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.MovieRepository
{
    public class TestMovieRepository : ITestMovieRepository
    {
        private readonly string path = @".\testMovies.json";

        public void Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TestMovie> Get(Guid id)
        {
            string readText = await File.ReadAllTextAsync(path);
            List<TestMovie> movies = JsonSerializer.Deserialize<List<TestMovie>>(readText,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return movies.FirstOrDefault(m => m.Id == id);
        }

        public async Task<IEnumerable<TestMovie>> GetAll()
        {
            string readText = await File.ReadAllTextAsync(path);
            List<TestMovie> movies = JsonSerializer.Deserialize<List<TestMovie>>(readText,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return movies;
        }

        public async Task<TestMovie> GetFirstMovie()
        {
            string readText = await File.ReadAllTextAsync(path);
            List<TestMovie> movies = JsonSerializer.Deserialize<List<TestMovie>>(readText,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return movies[0];
        }
    }
}
