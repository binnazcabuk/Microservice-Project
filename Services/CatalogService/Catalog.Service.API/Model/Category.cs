using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Service.API.Model
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
    }
}
