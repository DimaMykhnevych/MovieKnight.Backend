using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieKnight.BusinessLayer.Constants;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Services.CommentService;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieKnight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var result = await _commentService.GetAllComments();
            return Ok(result);
        }

        [HttpGet("getCommentsByUser/{userId}")]
        public async Task<IActionResult> GetCommentsByUser(Guid userId)
        {
            var result = await _commentService.GetCommentsByUser(userId);
            return Ok(result);
        }

        [HttpGet("getCommentsToMovie/{movieId}")]
        public async Task<IActionResult> GetCommentsToMovie(Guid movieId)
        {
            var result = await _commentService.GetCommentsToMovie(movieId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] AddCommentDto addCommentDto)
        {
            var currentUserId = new Guid(User.FindFirstValue(AuthorizationConstants.ID));
            addCommentDto.AppUserId = currentUserId;
            var result = await _commentService.AddComment(addCommentDto);
            return Ok(result);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            var result = await _commentService.DeleteComment(commentId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.AppUserId = new Guid(User.FindFirstValue(AuthorizationConstants.ID));
            await _commentService.UpdateComment(updateCommentDto);
            return Ok();
        }
    }
}
