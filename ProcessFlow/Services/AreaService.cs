using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProcessFlow.DataAccess;
using ProcessFlow.Models;
using ProcessFlow.Services.Interfaces;

namespace ProcessFlow.Services
{
    public class AreaService : IAreaService
    {
        private readonly IMongoCollection<AreaModel> _areaCollection;

        public AreaService(MongoContext mongoDatabaseContext)
        {
            _areaCollection = mongoDatabaseContext.AreaCollection;
        }

        public async Task<List<AreaModel>> GetAreasAsync() => 
            await _areaCollection.Find(x => true).ToListAsync();

        public async Task<AreaModel> GetAreaByIdAsync(string id) =>
            await _areaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(AreaModel area) => 
            await _areaCollection.InsertOneAsync(area);

        public async Task UpdateAsync(string id, AreaModel area) =>
            await _areaCollection.ReplaceOneAsync(x => x.Id == id, area);

        public async Task DeleteAsync(string id) =>
            await _areaCollection.DeleteOneAsync(x => x.Id == id);
    }
}
