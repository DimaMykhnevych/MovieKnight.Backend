using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieKnight.BusinessLayer.Factories;
using MovieKnight.BusinessLayer.Services.AuthorizationService;
using MovieKnight.BusinessLayer.Services.User;

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
        }
    }
}
