using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BooksApi.Core.Models.User
{   
    public class User
    {
        //[BsonElement("_id")]
        //[JsonProperty("_id")]
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
