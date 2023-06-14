using ProcessFlow.Models;

namespace ProcessFlow.Services.Interfaces
{
    public interface ISubProcessService
    {
        public Task<List<SubProcess>> GetSubProcessAsync(string areaId, string processId);
        public Task<SubProcess> CreateAsync(SubProcess subProcess);
        public Task<SubProcess> GetSubProcessByIdAsync(string areaId, string processId, string id);
        public Task<SubProcess> UpdateAsync(SubProcess subProcess);
        public Task DeleteAsync(string areaId, string processId, string id);

    }
}
