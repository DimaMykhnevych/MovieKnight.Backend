using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieKnight.BusinessLayer.Factories;

namespace MovieKnight.Web.Installers
{
    public class ServiceComponentsDiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //factories
            services.AddTransient<IAuthTokenFactory, AuthTokenFactory>();
        }
    }
}
