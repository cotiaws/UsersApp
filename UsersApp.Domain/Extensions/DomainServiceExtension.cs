using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Domain.Helpers;
using UsersApp.Domain.Interfaces.Services;
using UsersApp.Domain.Services;

namespace UsersApp.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<SHA256Helper>();
            return services;
        }
    }
}
