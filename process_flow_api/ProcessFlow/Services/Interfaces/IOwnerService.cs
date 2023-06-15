using ProcessFlow.Models;

namespace ProcessFlow.Services.Interfaces
{
    public interface IOwnerService
    {
        public Task<List<Owner>> GetOwnerAsync();
        public Task<Owner> GetOwnerByIdAsync(string id);
        public Task CreateAsync(Owner owner);
        public Task<Owner> UpdateAsync(Owner owner);
        public Task DeleteAsync(string id);
    }
}
