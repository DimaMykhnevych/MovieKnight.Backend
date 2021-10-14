using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieKnight.BusinessLayer.Options;

namespace MovieKnight.Web.Installers
{
    public class SecretsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IMDbApiDetails>(configuration.GetSection("IMDbApiDetails"));
            services.Configure<EmailServiceDetails>(configuration.GetSection("EmailServiceDetails"));
        }
}
}
