using MovieKnight.DataLayer.Models;

namespace MovieKnight.DataLayer.Builders.UserSearchQueryBuilder
{
    public interface IUserSearchQueryBuilder : IQueryBuilder<AppUser>
    {
        IUserSearchQueryBuilder SetBaseUserInfo();
        IUserSearchQueryBuilder SetUsername(string username);
    }
}
