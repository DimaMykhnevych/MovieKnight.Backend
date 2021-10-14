using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieKnight.BusinessLayer.Constants;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Services.WatchHistoryService;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieKnight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WatchHistoryController : ControllerBase
    {
        private readonly IWatchHistoryService _watchHistoryService;

        public WatchHistoryController(IWatchHistoryService watchHistoryService)
        {
            _watchHistoryService = watchHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWatchHistory()
        {
            var currentUserId = new Guid(User.FindFirstValue(AuthorizationConstants.ID));
            var result = await _watchHistoryService.GetWatchHistory(currentUserId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWatchHistoryItem(Guid id)
        {
            var result = await _watchHistoryService.GetWatchHistoryItem(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddWatchHistoryItem([FromBody] AddWatchHistoryDto watchHistoryDto)
        {
            watchHistoryDto.AppUserId = new Guid(User.FindFirstValue(AuthorizationConstants.ID)); 
            var result = await _watchHistoryService.AddWatchHistoryItem(watchHistoryDto);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
