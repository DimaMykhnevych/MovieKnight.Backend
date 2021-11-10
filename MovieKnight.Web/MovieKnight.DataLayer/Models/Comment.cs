using System;

namespace MovieKnight.DataLayer.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
