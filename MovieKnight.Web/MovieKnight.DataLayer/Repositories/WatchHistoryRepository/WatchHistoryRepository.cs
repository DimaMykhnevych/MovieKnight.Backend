using Microsoft.EntityFrameworkCore;
using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.WatchHistoryRepository
{
    public class WatchHistoryRepository : Repository<WatchHistory>, IWatchHistoryRepository
    {
        public WatchHistoryRepository(MovieKnightDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<WatchHistory>> GetWatchHistoryByUserId(Guid userId, Guid currentUserId)
        {
            if (await CanGetWatchHistory(userId, currentUserId))
            {
                return await Context.WatchHistory
                    .Where(r => r.AppUserId == userId)
                    .ToListAsync();
            }

            return null;
        }

        private async Task<bool> CanGetWatchHistory(Guid userId, Guid currentUserId)
        {
            var user = await Context.AppUsers
                .FirstOrDefaultAsync(r => r.Id == userId);
            
            if(user.StoryVisibility == Enums.StoryVisibility.Public)
            {
                return true;
            }

            if(user.StoryVisibility == Enums.StoryVisibility.Private)
            {
                return false;
            }

            var result = await Context.Friends
                .FirstOrDefaultAsync(r => r.Friend1Id == userId && r.Friend2Id == currentUserId);

            return result != null;
        }

        public async Task UpdateWatchHistoryItem(WatchHistory movie)
        {
            Context.WatchHistory.Update(movie);
            await Context.SaveChangesAsync();
        }

    }
}
