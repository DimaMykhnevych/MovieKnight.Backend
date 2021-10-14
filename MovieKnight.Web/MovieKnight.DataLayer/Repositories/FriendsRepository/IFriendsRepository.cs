using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.DataLayer.Repositories.FriendsRepository
{
    public interface IFriendsRepository : IRepository<Friends>
    {
        Task<IEnumerable<Friends>> GetUserFriends(Guid userId);
        Task<bool> DeleteUserFriend(Guid userId, Guid friendToDeleteId);
    }
}
