using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.FriendRequestsRepository
{
    public interface IFriendRequestsRepository : IRepository<FriendRequest>
    {
        Task<IEnumerable<FriendRequest>> GetFriendRequestsToCurrentUser(Guid userId);
        Task<IEnumerable<FriendRequest>> GetCurrentUserPendingRequests(Guid userId);
        Task<bool> DeleteRequest(Guid userId, Guid receiverID);
        Task UpdateRequest(FriendRequest request);
    }
}
