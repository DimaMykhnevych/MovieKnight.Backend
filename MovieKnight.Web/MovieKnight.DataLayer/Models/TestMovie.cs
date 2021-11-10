using System;

namespace MovieKnight.DataLayer.Models
{
    public class TestMovie
    {
        public Guid Id { get; set; }
        public string IMDbId { get; set; }
        public TestImdbMovieModel MovieInfo { get; set; }
    }
}
