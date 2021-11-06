using Microsoft.EntityFrameworkCore;
using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.CommentRepository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(MovieKnightDbContext context) : base(context)
        {
        }

        public async Task<bool> DeleteComment(Guid commentId)
        {
            var comment = Context
                .Comments
                .FirstOrDefault(c => c.Id == commentId);

            if (comment == null)
            {
                return false;
            }

            Context.Comments.Remove(comment);
            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByUser(Guid userId)
        {
            return await Context
                .Comments
                .Where(c => Context.WatchHistory.Where(wh => wh.AppUserId == userId && c.WatchHistoryId == wh.Id).Any())
                .ToListAsync();
            
        }

        public async Task<IEnumerable<Comment>> GetCommentsToMovie(Guid movieId)
        {
            return await Context
                .Comments
                .Where(c => Context.WatchHistory.Where(wh => wh.MovieId == movieId && c.WatchHistoryId == wh.Id).Any())
                .ToListAsync();
        }

        public async Task UpdateComment(Comment comment)
        {
            Context.Comments.Update(comment);
            await Context.SaveChangesAsync();
        }
    }
}
