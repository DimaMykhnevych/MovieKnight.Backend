using MovieKnight.BusinessLayer.DTOs;
using MovieKnight.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.Services.User
{
    public class UserService : IUserService
    {
        public Task<AppUser> CreateUserAsync(CreateUserDto userModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
