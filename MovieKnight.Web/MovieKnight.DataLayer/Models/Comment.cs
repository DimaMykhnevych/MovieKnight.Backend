using System;

namespace MovieKnight.DataLayer.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public Guid WatchHistoryId { get; set; }
        public WatchHistory WatchHistory { get; set; }

        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
