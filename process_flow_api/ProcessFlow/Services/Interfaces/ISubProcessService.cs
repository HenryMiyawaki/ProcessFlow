using ProcessFlow.Models;

namespace ProcessFlow.Services.Interfaces
{
    public interface ISubProcessService
    {
        public Task<List<SubProcess>> GetSubProcessAsync(string areaName, string processId);
        public Task<SubProcess> CreateAsync(SubProcess subProcess);
        public Task<SubProcess> GetSubProcessByIdAsync(string areaName, string processId, string id);
        public Task<SubProcess> UpdateAsync(SubProcess subProcess);
        public Task DeleteAsync(string areaName, string processId, string id);

    }
}
