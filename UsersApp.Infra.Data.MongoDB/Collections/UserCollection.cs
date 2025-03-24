using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersApp.Infra.Data.MongoDB.Collections
{
    /// <summary>
    /// Modelo de dados da collection que irá armazenar
    /// os dados dos usuarios no MongoDB
    /// </summary>
    public class UserCollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]        
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("created_at")]
        public DateTime? CreatedAt { get; set; }

        [BsonElement("role")]
        public string? Role { get; set; }
    }
}
