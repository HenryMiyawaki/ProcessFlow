namespace ProcessFlow.Models
{
    public class Area
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ProcessModel>? ProcessModels { get; set; }
    }
}
