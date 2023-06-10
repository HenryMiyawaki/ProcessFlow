using ProcessFlow.Models;
using ProcessFlow.Models.Dtos;

namespace ProcessFlow.Services.Interfaces
{
    public interface IAreaService
    {
        public Task<List<AreaDto>> GetAreasAsync();

        public Task<AreaDto> GetAreaByIdAsync(string id);

        public Task CreateAsync(AreaDto area);

        public Task UpdateAsync(string id, AreaDto area);

        public Task DeleteAsync(string id);
    }
}
