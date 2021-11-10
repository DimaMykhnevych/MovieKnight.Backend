using MovieKnight.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.CommentService
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetCommentsToMovie(Guid movieId);
        Task<IEnumerable<CommentDto>> GetCommentsByUser(Guid movieId);
        Task<bool> DeleteComment(Guid commentId);
        Task<CommentDto> AddComment(AddCommentDto addCommentDto);
        Task UpdateComment(UpdateCommentDto updateCommentDto);
    }
}
