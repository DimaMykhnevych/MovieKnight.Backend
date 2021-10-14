using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieKnight.BusinessLayer.Constants;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Services.FriendsRequestsService;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieKnight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendsRequestsController : ControllerBase
    {
        private readonly IFriendsRequestsService _friendsRequestsService;

        public FriendsRequestsController(IFriendsRequestsService friendsRequestsService)
        {
            _friendsRequestsService = friendsRequestsService;
        }

        [HttpGet]
        [Route("requestsToUser")]
        public async Task<IActionResult> GetFriendRequestsToCurrentUser()
        {
            var currentUserId = new Guid(User.FindFirstValue(AuthorizationConstants.ID));
            var result = await _friendsRequestsService.GetFriendRequestsToCurrentUser(currentUserId);
            return Ok(result);
        }

        [HttpGet]
        [Route("userPendingRequests")]
        public async Task<IActionResult> GetCurrentUserPendingRequests()
        {
            var currentUserId = new Guid(User.FindFirstValue(AuthorizationConstants.ID));
            var result = await _friendsRequestsService.GetCurrentUserPendingRequests(currentUserId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddFriendRequest([FromBody] AddFriendRequestDto friendRequestDto)
        {
            friendRequestDto.SenderId = new Guid(User.FindFirstValue(AuthorizationConstants.ID));
            var result = await _friendsRequestsService.AddFriendRequest(friendRequestDto);
            return Ok(result);
        }

        [HttpDelete("{receiverId}")]
        public async Task<IActionResult> DeleteRequest(Guid receiverId)
        {
            var currentUserId = new Guid(User.FindFirstValue(AuthorizationConstants.ID));
            var result = await _friendsRequestsService.DeleteRequest(currentUserId, receiverId);
            if (result)
                return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRequest([FromBody] UpdateRequestDto friendRequest)
        {
            friendRequest.ReceiverId = new Guid(User.FindFirstValue(AuthorizationConstants.ID));
            await _friendsRequestsService.UpdateRequestStatus(friendRequest);
            return Ok();
        }

    }
}
