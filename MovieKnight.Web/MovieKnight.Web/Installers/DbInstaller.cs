using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieKnight.DataLayer.DbContext;
using MovieKnight.Web.Options;

namespace MovieKnight.Web.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RemoteMySqlOptions>(configuration.GetSection("ConnectionStrings:Default"));
            string connectionString = configuration["ConnectionStrings:Default"];
            services.AddDbContext<MovieKnightDbContext>(opt =>
                    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }
    }
}
