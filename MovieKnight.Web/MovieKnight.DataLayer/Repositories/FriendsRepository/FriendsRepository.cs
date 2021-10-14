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
                .ToListAsync();
        }
    }
}
