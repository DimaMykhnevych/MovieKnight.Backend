using AutoMapper;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Services.FriendsService;
using MovieKnight.DataLayer.Enums;
using MovieKnight.DataLayer.Models;
using MovieKnight.DataLayer.Repositories.FriendRequestsRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.FriendsRequestsService
{
    public class FriendsRequestsService : IFriendsRequestsService
    {
        private readonly IFriendRequestsRepository _friendRequestsRepository;
        private readonly IMapper _mapper;
        private readonly IFriendsService _friendsService;

        public FriendsRequestsService(IFriendRequestsRepository friendRequestsRepository, 
            IMapper mapper, IFriendsService friendsService)
        {
            _friendRequestsRepository = friendRequestsRepository;
            _mapper = mapper;
            _friendsService = friendsService;
        }

        public async Task<FriendRequestDto> AddFriendRequest(AddFriendRequestDto friendRequestDto)
        {
            var friendRequest = _mapper.Map<FriendRequest>(friendRequestDto);
            friendRequest.RequestDate = DateTime.Now;
            await _friendRequestsRepository.Insert(friendRequest);
            await _friendRequestsRepository.Save();
            return _mapper.Map<FriendRequestDto>(friendRequest);
        }

        public async Task<bool> DeleteRequest(Guid userId, Guid receiverID)
        {
            var result = await _friendRequestsRepository.DeleteRequest(userId, receiverID);
            return result;
        }

        public async Task<IEnumerable<FriendRequestDto>> GetCurrentUserPendingRequests(Guid userId)
        {
            var requests = await _friendRequestsRepository.GetCurrentUserPendingRequests(userId);
            return _mapper.Map<IEnumerable<FriendRequestDto>>(requests);
        }

        public async Task<IEnumerable<FriendRequestDto>> GetFriendRequestsToCurrentUser(Guid userId)
        {
            var requests = await _friendRequestsRepository.GetFriendRequestsToCurrentUser(userId);
            return _mapper.Map<IEnumerable<FriendRequestDto>>(requests);
        }

        public async Task UpdateRequestStatus(UpdateRequestDto requestDto)
        {
            var request = _mapper.Map<FriendRequest>(requestDto);
            await _friendRequestsRepository.UpdateRequest(request);
            switch (request.FriendRequestStatus)
            {
                case FriendRequestStatus.Accepted:
                    await _friendsService.AddFriend(requestDto.ReceiverId, requestDto.SenderId);
                    await _friendsService.AddFriend(requestDto.SenderId, requestDto.ReceiverId);
                    return;
                default:
                    return;
            }
        }
    }
}
