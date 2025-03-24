using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Infra.Data.MongoDB.Collections;

namespace UsersApp.Infra.Data.MongoDB.Contexts
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDBContext(IConfiguration configuration)
        {
            var connectionString = configuration["MongoDBConnection:UsersApp"];
            var database = configuration["MongoDBConnection:Database"];

            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase(database);
        }

        #region Mapeamento das collections do banco de dados

        public IMongoCollection<UserCollection> Users
            => _mongoDatabase.GetCollection<UserCollection>("users");

        #endregion
    }
}
