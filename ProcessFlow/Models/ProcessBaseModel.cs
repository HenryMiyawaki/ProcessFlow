using MongoDB.Bson.Serialization.Attributes;

namespace ProcessFlow.Models
{
    public class ProcessBaseModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string[]? UsedSystems { get; set; }
        public OwnerModel[]? Owners { get; set; }
    }
}
