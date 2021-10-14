using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Services.WatchHistoryService;
using System;
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
            var result = await _watchHistoryService.GetWatchHistory();
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
            var result = await _watchHistoryService.AddWatchHistoryItem(watchHistoryDto);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }
    }
}
