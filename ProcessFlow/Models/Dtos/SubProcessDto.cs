namespace ProcessFlow.Models.Dtos
{
    public class SubProcessDto : ProcessBaseDto
    {
        public string? Documentation { get; set; }
        public ProcessModel? Process { get; set; }
    }
}
