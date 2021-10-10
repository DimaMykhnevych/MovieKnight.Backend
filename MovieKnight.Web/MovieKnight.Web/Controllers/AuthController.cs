using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieKnight.BusinessLayer.Services.AuthorizationService;
using MovieKnight.DataLayer.Models.Auth;
using System.Threading.Tasks;

namespace MovieKnight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly BaseAuthorizationService _authorizationService;
        public AuthController(BaseAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public async Task<IActionResult> Login([FromBody] AuthSignInModel model)
        {
            JWTTokenStatusResult result = await _authorizationService.GenerateTokenAsync(model);
            if (!result.IsAuthorized) { return NotFound(); }

            return Ok(result);
        }

        [HttpGet]
        [Route("user-info")]
        public async Task<IActionResult> GetUserInfo()
        {
            string currentUserName = User.Identity.Name;
            UserAuthInfo userInfo = await _authorizationService.GetUserInfoAsync(currentUserName);

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }
    }
}
