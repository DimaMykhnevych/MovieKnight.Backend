using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.DataLayer.Models;
using System;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.User
{
    public interface IUserService
    {
        Task<AppUser> GetUserByUsername(string username);
        Task<AppUser> CreateUserAsync(CreateUserDto userModel);

        //TODO
        //Task<AppUser> UpdateUserAsync(UpdateUserModel userModel);
        Task DeleteUser(Guid userId);
    }
}
