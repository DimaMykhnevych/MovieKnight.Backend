using System;
using System.Collections.Generic;

namespace MovieKnight.DataLayer.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string IMDbId { get; set; }
        public IEnumerable<WatchHistory> WatchHistory { get; set; }

    }
}
