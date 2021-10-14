using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieKnight.BusinessLayer.Clients.MovieClient;
using MovieKnight.BusinessLayer.Factories;
using MovieKnight.BusinessLayer.Services.AuthorizationService;
using MovieKnight.BusinessLayer.Services.MovieService;
using MovieKnight.BusinessLayer.Services.User;
using MovieKnight.BusinessLayer.Services.WatchHistoryService;
using MovieKnight.DataLayer.Repositories.MovieRepository;
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

            //clients
            services.AddHttpClient<IImdbMovieClient, ImdbMovieClient>();

            //repositories
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IWatchHistoryRepository, WatchHistoryRepository>();
        }
    }
}
