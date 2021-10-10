using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieKnight.DataLayer.DbContext;

namespace MovieKnight.Web.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieKnightDbContext>(opt =>
                    opt.UseSqlServer(configuration.GetConnectionString("Default")));
        }
    }
}
