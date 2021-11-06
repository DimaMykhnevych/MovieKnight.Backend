using MovieKnight.DataLayer.Models;
using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid WatchHistoryId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
