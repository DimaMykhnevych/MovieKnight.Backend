using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class GetWatchHistoryStatisticsDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
