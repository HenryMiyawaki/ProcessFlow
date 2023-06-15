namespace ProcessFlow.Models
{
    public class ProcessBase
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<string>? UsedSystems { get; set; }
        public List<string>? OwnersIds { get; set; }
        public string? AreaName { get; set; }
        public string? AreaId { get; set; }
    }
}
