using MongoDB.Bson.Serialization.Attributes;

namespace ProcessFlow.Models
{
    public class ProcessModel : ProcessBaseModel
    {
        public List<SubProcessModel>? SubProcessModels { get; set; }
    }
}
