using ProcessFlow.Models.Dtos;

namespace ProcessFlow.Services.Interfaces
{
    public interface ISubProcessService
    {
        public Task<List<SubProcessDto>> GetSubProcessAsync();
        public Task CreateAsync(SubProcessDto subProcess);
    }
}
