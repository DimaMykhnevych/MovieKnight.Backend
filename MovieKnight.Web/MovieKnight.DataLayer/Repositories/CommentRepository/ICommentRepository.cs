using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.CommentRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<bool> DeleteComment(Guid commentId);
        Task<IEnumerable<Comment>> GetCommentsToMovie(Guid movieId);
        Task<IEnumerable<Comment>> GetCommentsByUser(Guid movieId);
        Task UpdateComment(Comment comment);
    }
}
