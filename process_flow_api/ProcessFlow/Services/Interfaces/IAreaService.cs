using ProcessFlow.Models;
namespace ProcessFlow.Services.Interfaces
{
    public interface IAreaService
    {
        public Task<List<Area>> GetAreaAsync();

        public Task<Area> GetAreaByIdAsync(string id);

        public Task<Area> GetAreaByNameAsync(string name);

        public Task CreateAreaAsync(Area area);

        public Task<Area> UpdateAreaAsync(Area area);

        public Task DeleteAreaAsync(string id);
    }
}
