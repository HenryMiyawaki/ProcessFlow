using ProcessFlow.Models;

namespace ProcessFlow.Services.Interfaces
{
    public interface IProcessService
    {
        public Task<List<Process>> GetProcessAsync(string areaName);
        public Task<Process> GetProcessByIdAsync(string areaId, string id);
        public Task<Process> CreateProcessAsync(Process process);
        public Task<Process> UpdateProcessAsync(Process process);
        public Task DeleteProcessAsync(string areaId, string id);

    }
}
