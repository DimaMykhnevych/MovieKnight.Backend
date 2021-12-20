namespace MovieKnight.BusinessLayer.DTOs
{
    public class WatchHistoryStatisticsDto
    {
        public int UsersCount { get; set; }
        public int MoviesCount { get; set; }
        public int SuggestionsCount { get; set; }
        public double AverageRating { get; set; }
        public WatchHistoryStatisticsDto()
        {
            UsersCount = 0;
            MoviesCount = 0;
            SuggestionsCount = 0;
            AverageRating = 0;
        }
    }
}
