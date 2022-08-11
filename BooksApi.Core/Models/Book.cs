using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace BooksApi.Models
{
    public class Book
    {
       /* [BsonElement("_id")]
        [JsonProperty("_id")]*/
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId? Id { get; set; }

        /*[BsonElement("Name")]
        [JsonProperty("Name")]*/
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
    }
}
