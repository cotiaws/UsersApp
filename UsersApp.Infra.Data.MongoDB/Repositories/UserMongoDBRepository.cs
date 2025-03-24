using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApp.Infra.Data.MongoDB.Collections;
using UsersApp.Infra.Data.MongoDB.Contexts;

namespace UsersApp.Infra.Data.MongoDB.Repositories
{
    public class UserMongoDBRepository
    {
        private readonly IMongoCollection<UserCollection> _userCollection;

        public UserMongoDBRepository(MongoDBContext context)
        {
            _userCollection = context.Users;
        }

        public void Add(UserCollection user)
        {
            _userCollection.InsertOne(user);
        }

        public void Update(Guid id, UserCollection user)
        {
            _userCollection.ReplaceOne(u => u.Id == id, user);
        }

        public void Delete(Guid id)
        {
            _userCollection.DeleteOne(u => u.Id == id);
        }

        public UserCollection? GetById(Guid id)
        {
            return _userCollection.Find(u => u.Id == id).FirstOrDefault();
        }

        public UserCollection? GetByEmail(string email)
        {
            return _userCollection.Find(u => u.Email.Equals(email)).FirstOrDefault();
        }
    }
}
