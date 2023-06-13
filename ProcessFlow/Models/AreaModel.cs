using MongoDB.Bson.Serialization.Attributes;

namespace ProcessFlow.Models
{
    public class AreaModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<ProcessModel>? ProcessModels { get; set; }
    }
}
