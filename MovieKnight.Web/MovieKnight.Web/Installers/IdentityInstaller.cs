using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MovieKnight.DataLayer.DbContext;
using MovieKnight.DataLayer.Models;
using MovieKnight.DataLayer.Models.Auth;
using System;

namespace MovieKnight.Web.Installers
{
    public class IdentityInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, UserRole>()
                .AddEntityFrameworkStores<MovieKnightDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.IncludeErrorDetails = true;

                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = false,
                    ValidIssuer = AuthOptions.ISSUER,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });

            services.AddAuthorization();
        }
    }
}
