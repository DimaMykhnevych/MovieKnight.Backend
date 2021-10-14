using Microsoft.EntityFrameworkCore;
using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Enums;
using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.FriendRequestsRepository
{
    public class FriendRequestsRepository : Repository<FriendRequest>, IFriendRequestsRepository
    {
        public FriendRequestsRepository(MovieKnightDbContext context) : base(context)
        {
        }

        public async Task<bool> DeleteRequest(Guid userId, Guid receiverID)
        {
            var request = Context.FriendRequests
                .FirstOrDefault(r => r.SenderId == userId && r.ReceiverId == receiverID);
            if (request == null) return false;
            Context.FriendRequests.Remove(request);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FriendRequest>> GetCurrentUserPendingRequests(Guid userId)
        {
            return await Context.FriendRequests
                .Where(r => r.SenderId == userId && r.FriendRequestStatus == FriendRequestStatus.Pending)
                .Include(r => r.Receiver)
                .ToListAsync();
        }

        public async Task<IEnumerable<FriendRequest>> GetFriendRequestsToCurrentUser(Guid userId)
        {
            return await Context.FriendRequests
                .Where(r => r.ReceiverId == userId)
                .Include(r => r.Sender)
                .ToListAsync();
        }

        public async Task UpdateRequest(FriendRequest request)
        {
            Context.FriendRequests.Update(request);
            await Context.SaveChangesAsync();
        }
    }
}
