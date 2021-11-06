using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.DataLayer.Models;
using MovieKnight.DataLayer.Repositories.CommentRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<CommentDto> AddComment(CommentDto addCommentDto)
        {
            var comment = _mapper.Map<Comment>(addCommentDto);
            comment.CommentDate = DateTime.Now;
            comment.Id = new Guid();
            await _commentRepository.Insert(comment);
            await _commentRepository.Save();
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<bool> DeleteComment(Guid commentId)
        {
            var result = await _commentRepository.DeleteComment(commentId);
            return result;
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByUser(Guid userId)
        {
            var comments = await _commentRepository.GetCommentsByUser(userId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsToMovie(Guid movieId)
        {
            var comments = await _commentRepository.GetCommentsToMovie(movieId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task UpdateComment(CommentDto updateCommentDto)
        {
            var comment = _mapper.Map<Comment>(updateCommentDto);
            await _commentRepository.UpdateComment(comment);
        }
    }
}
