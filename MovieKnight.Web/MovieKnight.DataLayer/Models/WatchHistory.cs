using System;

namespace MovieKnight.DataLayer.Models
{
    public class WatchHistory
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid AppUserId { get; set; }
        public int Rating { get; set; }

        public AppUser AppUser { get; set; }
        public Movie Movie { get; set; }

        public DateTime WatchDate { get; set; }
    }
}
