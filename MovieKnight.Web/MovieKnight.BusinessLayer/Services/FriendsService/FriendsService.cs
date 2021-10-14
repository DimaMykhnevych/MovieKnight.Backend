using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
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
        private readonly IMapper _mapper;

        public FriendsService(IFriendsRepository friendsRepository, IMapper mapper)
        {
            _friendsRepository = friendsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppUser>> GetUserFriends(Guid userId)
        {
            var friends = await _friendsRepository.GetUserFriends(userId);
            return friends.ToList().Select(f => f.Friend2);
        }

        public async Task<bool> DeleteFriend(Guid userId, Guid friendToDelete)
        {
            var res = await _friendsRepository.DeleteUserFriend(userId, friendToDelete);
            return res;
        }

        public async Task<FriendsDto> AddFriend(Guid userId, Guid friendId)
        {
            var friend = new Friends() { Friend1Id = userId, Friend2Id = friendId };
            var added = await _friendsRepository.Insert(friend);
            await _friendsRepository.Save();
            return _mapper.Map<FriendsDto>(added);
        }
    }
}
