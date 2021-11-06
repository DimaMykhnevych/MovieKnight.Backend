using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<AppUser>> SearchUsers(string username);
        Task<AppUser> GetUserByUsername(string username);
        Task<AppUser> CreateUserAsync(CreateUserDto userModel);
        Task<AppUser> UpdateUserAsync(UpdateUserDto userModel);
        Task DeleteUser(Guid userId);
        Task<ConfirmEmailDto> ConfirmEmail(ConfirmEmailDto confirmEmailDto);
    }
}
