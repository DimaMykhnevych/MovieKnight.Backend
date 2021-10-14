using MovieKnight.DataLayer.Models;
using MovieKnight.DataLayer.Repositories.FriendsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.FriendsService
{
    public class FriendsService : IFriendsService
    {
        private readonly IFriendsRepository _friendsRepository;

        public FriendsService(IFriendsRepository friendsRepository)
        {
            _friendsRepository = friendsRepository;
        }

        public async Task<IEnumerable<AppUser>> GetUserFriends(Guid userId)
        {
            var friends = await _friendsRepository.GetUserFriends(userId);
            return friends.ToList().Select(f => f.Friend2);
        }
    }
}
