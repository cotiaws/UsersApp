using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Infra.Data.MongoDB.Contexts;
using UsersApp.Infra.Data.MongoDB.Repositories;

namespace UsersApp.Infra.Data.MongoDB.Extensions
{
    public static class MongoDBExtension
    {
        public static IServiceCollection AddMongoDBExtension(this IServiceCollection services)
        {
            services.AddTransient<MongoDBContext>();
            services.AddTransient<UserMongoDBRepository>();

            return services;
        }
    }
}
