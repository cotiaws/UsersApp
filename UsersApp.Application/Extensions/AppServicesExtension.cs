using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Application.Interfaces;
using UsersApp.Application.Mappings;
using UsersApp.Application.Services;
using UsersApp.Domain.Enums;

namespace UsersApp.Application.Extensions
{
    public static class AppServicesExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UserAppService).Assembly));

            services.AddAutoMapper(typeof(ProfileMapping));

            services.AddTransient<IUserAppService, UserAppService>();

            return services;
        }
    }
}
