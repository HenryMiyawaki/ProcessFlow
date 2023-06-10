using MongoDB.Driver;
using ProcessFlow.DataAccess;
using ProcessFlow.Models;
using ProcessFlow.Services.Interfaces;

namespace ProcessFlow.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IMongoCollection<ProcessModel> _processCollection;

        public ProcessService(MongoContext mongoDatabaseContext)
        {
            _processCollection = mongoDatabaseContext.ProcessCollection;
        }

        public async Task<List<ProcessModel>> GetProcessAsync() =>
            await _processCollection.Find(x => true).ToListAsync();

        public async Task CreateAsync(ProcessModel process) =>
            await _processCollection.InsertOneAsync(process);
    }
}
