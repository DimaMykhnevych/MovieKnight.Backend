using Microsoft.EntityFrameworkCore;
using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;
using System;
using System.Linq;

namespace MovieKnight.DataLayer.Builders.UserSearchQueryBuilder
{
    public class UserSearchQueryBuilder : IUserSearchQueryBuilder
    {
        private readonly MovieKnightDbContext _dbContext;
        private IQueryable<AppUser> _query;

        public UserSearchQueryBuilder(MovieKnightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<AppUser> Build()
        {
            IQueryable<AppUser> result = _query;
            _query = null;
            return result;
        }

        public IUserSearchQueryBuilder SetBaseUserInfo()
        {
            _query = _dbContext.AppUsers.Include(u => u.Friends).ThenInclude(u => u.Friend2).AsNoTracking();
            return this;
        }

        public IUserSearchQueryBuilder SetUsername(string username)
        {
            if(!String.IsNullOrEmpty(username))
            {
                _query = _query.Where(u => u.UserName.ToLower().Contains(username.ToLower())
                                      && u.Role != Role.Admin);
            }
            return this;
        }
    }
}
