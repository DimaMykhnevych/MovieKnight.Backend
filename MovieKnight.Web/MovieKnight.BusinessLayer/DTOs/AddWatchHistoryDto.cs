using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class AddWatchHistoryDto
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid AppUserId { get; set; }
        public int Rating { get; set; }
    }
}
