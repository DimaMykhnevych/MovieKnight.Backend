using MovieKnight.DataLayer.Models;
using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class WatchHistoryDto
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid AppUserId { get; set; }
        public int Rating { get; set; }

        public AppUser AppUser { get; set; }
        public MovieModel Movie { get; set; }
    }
}
