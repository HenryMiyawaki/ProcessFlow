using MongoDB.Bson.Serialization.Attributes;

namespace ProcessFlow.Models
{
    public class ProcessModel : ProcessBaseModel
    {
        public AreaModel? Area { get; set; }
    }
}
