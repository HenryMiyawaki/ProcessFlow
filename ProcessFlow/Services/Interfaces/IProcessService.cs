using ProcessFlow.Models;

namespace ProcessFlow.Services.Interfaces
{
    public interface IProcessService
    {
        public Task<List<ProcessModel>> GetProcessAsync();
        public Task CreateAsync(ProcessModel process);
    }
}
