namespace ProcessFlow.Models.Dtos
{
    public class ProcessBaseDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string[]? UsedSystems { get; set; }
        public OwnerModel[]? Owners { get; set; }
    }
}
