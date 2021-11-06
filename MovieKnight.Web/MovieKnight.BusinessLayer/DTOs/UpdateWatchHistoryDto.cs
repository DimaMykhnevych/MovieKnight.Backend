using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class UpdateWatchHistoryDto
    {
        public Guid WatchHistoryId { get; set; }
        public int NewRating { get; set; }

    }
}
