using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class SearchWatchHistoryDto
    {
        public Guid UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? FromRate { get; set; }
        public int? ToRate { get; set; }
    }
}
