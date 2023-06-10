using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProcessFlow.Models;

namespace ProcessFlow.DataAccess
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<ProcessDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _database = mongoClient.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<AreaModel> AreaCollection =>
            _database.GetCollection<AreaModel>("Area");
    }
}
