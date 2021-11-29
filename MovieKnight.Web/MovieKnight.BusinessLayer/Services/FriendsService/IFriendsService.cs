using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.FriendsService
{
    public interface IFriendsService
    {
        Task<IEnumerable<AppUserDto>> GetUserFriends(Guid userId);
        Task<bool> DeleteFriend(Guid userId, Guid friendToDelete);
        Task<FriendsDto> AddFriend(Guid userId, Guid friendId);
    }
}
