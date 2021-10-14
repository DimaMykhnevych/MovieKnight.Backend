using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MovieKnight.BusinessLayer.Constants;
using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.BusinessLayer.Exceptions;
using MovieKnight.BusinessLayer.Services.User;
using MovieKnight.DataLayer.Models;
using System;
using System.Threading.Tasks;

namespace MovieKnight.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] string username)
        {
            var results = await _service.SearchUsers(username);
            return Ok(results);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            return Ok(await _service.GetUserByUsername(username));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserDto model)
        {
            model.Role = "Client";
            try
            {
                return Ok(await _service.CreateUserAsync(model));
            }
            catch (UsernameAlreadyTakenException)
            {
                return BadRequest(AddModelStateError("username", ErrorMessagesConstants.USERNAME_ALREADY_TAKEN));
            }
        }

        [HttpPost("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDto confirmEmailDto)
        {
            ConfirmEmailDto confirmEmail = await _service.ConfirmEmail(confirmEmailDto);
            if (confirmEmail == null)
                return BadRequest("Invalid Email Confirmation Request");
            return Ok(confirmEmail);
        }

        //[HttpPut]
        //public async Task<IActionResult> Put([FromBody] UpdateUserModel model)
        //{
        //    try
        //    {
        //        return Ok(await _service.UpdateUserAsync(model));
        //    }
        //    catch (InvalidUserPasswordException)
        //    {
        //        return BadRequest(AddModelStateError("password", ErrorMessagesConstants.INVALID_PASSWORD));
        //    }
        //    catch (UsernameAlreadyTakenException)
        //    {
        //        return BadRequest(AddModelStateError("username", ErrorMessagesConstants.USERNAME_ALREADY_TAKEN));
        //    }
        //}

        //[HttpPut("{id:guid}")]
        //public async Task<IActionResult> DeactivateUser(Guid id)
        //{
        //    await _service.DeactivateUser(id);
        //    return Ok();
        //}

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteUser(id);
            return Ok();
        }

        private ModelStateDictionary AddModelStateError(String field, String error)
        {
            ModelStateDictionary modelState = new ModelStateDictionary();
            modelState.TryAddModelError(field, error);
            return modelState;
        }
    }
}
