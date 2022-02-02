using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Service.API.Model
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string description{ get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal price { get; set; }

        public string userId { get; set; }
        public string picture { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public BsonDateTime createdTime { get; set; }

        public Feature feature  { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string categoryId { get; set; }

        [BsonIgnore] //veritabanında karşılığı yok
        public Category category { get; set; }

    }
}
