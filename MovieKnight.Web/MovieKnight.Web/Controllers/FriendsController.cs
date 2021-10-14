using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieKnight.BusinessLayer.Constants;
using MovieKnight.BusinessLayer.Services.FriendsService;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieKnight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUserFriends()
        {
            var currentUserId = new Guid(User.FindFirstValue(AuthorizationConstants.ID));
            var friends = await _friendsService.GetUserFriends(currentUserId);
            return Ok(friends);
        }
    }
}
