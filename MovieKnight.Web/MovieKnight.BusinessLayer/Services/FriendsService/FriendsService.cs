using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.DataLayer.Models;
using MovieKnight.DataLayer.Repositories.FriendRequestsRepository;
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
        private readonly IFriendRequestsRepository _friendsRequestRepository;
        private readonly IMapper _mapper;

        public FriendsService(IFriendsRepository friendsRepository,
            IFriendRequestsRepository friendsRequestRepository,
            IMapper mapper)
        {
            _friendsRepository = friendsRepository;
            _friendsRequestRepository = friendsRequestRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppUserDto>> GetUserFriends(Guid userId)
        {
            var friends = await _friendsRepository.GetUserFriends(userId);
            var userFriends = friends.ToList().Select(f => f.Friend2);
            return _mapper.Map<IEnumerable<AppUserDto>>(userFriends);
        }

        public async Task<bool> DeleteFriend(Guid userId, Guid friendToDelete)
        {
            var res = await _friendsRepository.DeleteUserFriend(userId, friendToDelete);
            var deleteRequestRes = await _friendsRequestRepository.DeleteRequestByCurrentUserId(userId);
            return res && deleteRequestRes;
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
