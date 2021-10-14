using MovieKnight.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.FriendsRequestsService
{
    public interface IFriendsRequestsService
    {
        Task<IEnumerable<FriendRequestDto>> GetFriendRequestsToCurrentUser(Guid userId);
        Task<IEnumerable<FriendRequestDto>> GetCurrentUserPendingRequests(Guid userId);
        Task<FriendRequestDto> AddFriendRequest(AddFriendRequestDto friendRequestDto);
        Task<bool> DeleteRequest(Guid userId, Guid receiverID);
        Task UpdateRequestStatus(UpdateRequestDto request);
    }
}
