using ProcessFlow.Models;

namespace ProcessFlow.Services.Interfaces
{
    public interface IAreaService
    {
        public Task<List<AreaModel>> GetAreasAsync();

        public Task<AreaModel> GetAreaByIdAsync(string id);

        public Task CreateAsync(AreaModel area);

        public Task UpdateAsync(string id, AreaModel area);

        public Task DeleteAsync(string id);
    }
}
