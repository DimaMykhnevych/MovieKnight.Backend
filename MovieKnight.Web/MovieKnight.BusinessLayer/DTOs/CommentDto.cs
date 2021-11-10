using MovieKnight.DataLayer.Models;
using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid MovieId { get; set; }

        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
