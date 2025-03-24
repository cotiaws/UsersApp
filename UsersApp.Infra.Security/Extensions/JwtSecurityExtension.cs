using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Interfaces.Security;
using UsersApp.Infra.Security.Services;

namespace UsersApp.Infra.Security.Extensions
{
    public static class JwtSecurityExtension
    {
        public static IServiceCollection AddJwtSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //JWT Bearer
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //JWT Bearer
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]))
                };
            });

            services.AddTransient<IUserSecurity, UserSecurity>();
            return services;
        }
    }
}
