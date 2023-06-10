using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProcessFlow.Models;

namespace ProcessFlow.Services
{
    public class AreaService
    {
        private readonly IMongoCollection<AreaModel> _areaCollection;

        public AreaService(IOptions<AreaDatabaseSettings> areaServices)
        {
            var mongoClient = new MongoClient(areaServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(areaServices.Value.DatabaseName);

            _areaCollection = mongoDatabase.GetCollection<AreaModel>(areaServices.Value.AreaCollectionName);
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
