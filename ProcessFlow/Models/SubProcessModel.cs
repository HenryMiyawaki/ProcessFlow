using MongoDB.Bson.Serialization.Attributes;

namespace ProcessFlow.Models
{
    public class SubProcessModel : ProcessBaseModel
    {
        public string Documentation { get; set; }
        public ProcessModel Process { get; set; }
    }
}
