using Microsoft.AspNetCore.Identity;
using MovieKnight.BusinessLayer.Constants;
using MovieKnight.BusinessLayer.Factories;
using MovieKnight.DataLayer.Models;
using MovieKnight.DataLayer.Models.Auth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.AuthorizationService
{
    public class AppUserAuthorizationService : BaseAuthorizationService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserAuthorizationService(
            IAuthTokenFactory tokenFactory,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
            : base(tokenFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public override async Task<IEnumerable<Claim>> GetUserClaimsAsync(AuthSignInModel model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return new List<Claim> { };
            }

            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName.ToString()),
                new Claim(AuthorizationConstants.ID, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };
        }

        public async override Task<bool> VerifyUserAsync(AuthSignInModel model)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return false;
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            return result.Succeeded;
        }

        public async override Task<UserAuthInfo> GetUserInfoAsync(string userName)
        {
            if (userName == null) return null;
            AppUser user = await _userManager.FindByNameAsync(userName);

            UserAuthInfo info = new UserAuthInfo
            {
                Role = user.Role,
                UserId = user.Id,
                Username = user.UserName,
                RegistryDate = user.RegistryDate,
                BirthdayDate = user.BirthdayDate,
                Email = user.Email,
                StoryVisibility = user.StoryVisibility
            };

            return info;
        }
    }
}
