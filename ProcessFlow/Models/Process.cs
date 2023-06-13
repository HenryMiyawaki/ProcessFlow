namespace ProcessFlow.Models
{
    public class Process : ProcessBase
    {
        public string? AreaId { get; set; }
        public List<SubProcessModel>? SubProcessModels { get; set; }
    }
}
