using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.FriendsService
{
    public interface IFriendsService
    {
        Task<IEnumerable<AppUser>> GetUserFriends(Guid userId);
    }
}
