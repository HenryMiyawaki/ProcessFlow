using ProcessFlow.Models;

namespace ProcessFlow.Services.Interfaces
{
    public interface IOwnerService
    {
        public Task<List<OwnerModel>> GetOwnerAsync();
        public Task<OwnerModel> GetOwnerByIdAsync(string id);
        public Task CreateAsync(OwnerModel ownerDto);
        public Task UpdateAsync(string id, OwnerModel ownerDto);
        public Task DeleteAsync(string id);
    }
}
