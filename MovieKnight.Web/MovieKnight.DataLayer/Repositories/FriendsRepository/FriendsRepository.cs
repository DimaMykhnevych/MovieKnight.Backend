using Microsoft.EntityFrameworkCore;
using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.FriendsRepository
{
    public class FriendsRepository : Repository<Friends>, IFriendsRepository
    {
        public FriendsRepository(MovieKnightDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Friends>> GetUserFriends(Guid userId)
        {
            return await Context.Friends
                .Where(f => f.Friend1Id == userId)
                .Include(f => f.Friend2)
                .ThenInclude(f => f.WatchHistory)
                .ThenInclude(wh => wh.Movie)
                .ToListAsync();
        }

        public async Task<bool> DeleteUserFriend(Guid userId, Guid friendToDeleteId)
        {
            var friend1ToDelete = await Context.Friends
                .FirstOrDefaultAsync(f => f.Friend1Id == userId && f.Friend2Id == friendToDeleteId);
            var friend2ToDelete = await Context.Friends
                .FirstOrDefaultAsync(f => f.Friend1Id == friendToDeleteId && f.Friend2Id == userId);
            if (friend1ToDelete == null || friend2ToDelete == null) return false;
            Context.Friends.Remove(friend1ToDelete);
            Context.Friends.Remove(friend2ToDelete);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
