using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieKnight.BusinessLayer.Clients.MovieClient;
using MovieKnight.BusinessLayer.Factories;
using MovieKnight.BusinessLayer.Services.AuthorizationService;
using MovieKnight.BusinessLayer.Services.CommentService;
using MovieKnight.BusinessLayer.Services.EmailService;
using MovieKnight.BusinessLayer.Services.FriendsRequestsService;
using MovieKnight.BusinessLayer.Services.FriendsService;
using MovieKnight.BusinessLayer.Services.MovieService;
using MovieKnight.BusinessLayer.Services.User;
using MovieKnight.BusinessLayer.Services.WatchHistoryService;
using MovieKnight.DataLayer.Builders.UserSearchQueryBuilder;
using MovieKnight.DataLayer.Repositories.CommentRepository;
using MovieKnight.DataLayer.Repositories.FriendRequestsRepository;
using MovieKnight.DataLayer.Repositories.FriendsRepository;
using MovieKnight.DataLayer.Repositories.MovieRepository;
using MovieKnight.DataLayer.Repositories.UserRepository;
using MovieKnight.DataLayer.Repositories.WatchHistoryRepository;

namespace MovieKnight.Web.Installers
{
    public class ServiceComponentsDiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //factories
            services.AddTransient<IAuthTokenFactory, AuthTokenFactory>();

            //serivces
            services.AddTransient<BaseAuthorizationService, AppUserAuthorizationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IWatchHistoryService, WatchHistoryService>();
            services.AddTransient<IFriendsService, FriendsService>();
            services.AddTransient<IFriendsRequestsService, FriendsRequestsService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICommentService, CommentService>();

            //clients
            services.AddHttpClient<IImdbMovieClient, ImdbMovieClient>();

            //builders
            services.AddTransient<IUserSearchQueryBuilder, UserSearchQueryBuilder>();

            //repositories
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IWatchHistoryRepository, WatchHistoryRepository>();
            services.AddTransient<IFriendsRepository, FriendsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFriendRequestsRepository, FriendRequestsRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
        }
    }
}
