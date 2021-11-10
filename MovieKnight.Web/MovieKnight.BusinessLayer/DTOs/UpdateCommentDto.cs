using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class UpdateCommentDto
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public Guid MovieId { get; set; }

        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
