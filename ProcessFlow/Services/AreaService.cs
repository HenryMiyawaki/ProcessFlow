using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using ProcessFlow.Controllers.ErrorHandler;
using ProcessFlow.DataAccess;
using ProcessFlow.Models;
using ProcessFlow.Services.Interfaces;
using System.Net;

namespace ProcessFlow.Services
{
    public class AreaService : IAreaService
    {
        private readonly IMongoCollection<AreaModel> _areaCollection;
        private readonly IMapper _mapper;

        public AreaService(MongoContext mongoDatabaseContext, IMapper mapper)
        {
            _areaCollection = mongoDatabaseContext.AreaCollection;
            _mapper = mapper;
        }

        public async Task<List<Area>> GetAreaAsync()
        {
            var areaModels = await _areaCollection.Find(_ => true).ToListAsync();

            return _mapper.Map<List<Area>>(areaModels);
        }

        public async Task<Area> GetAreaByIdAsync(string id)
        {
            var areaModel = await _areaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            if(areaModel == null)
                throw new NotFoundException("Area not found");

            return _mapper.Map<Area>(areaModel);
        }

        public async Task CreateAreaAsync(Area area)
        {
            if (string.IsNullOrEmpty(area.Name))
            {
                throw new BadRequestException("Name is required");
            }

            var areaModel = _mapper.Map<AreaModel>(area);

            await _areaCollection.InsertOneAsync(areaModel);
        }

        public async Task<Area> UpdateAreaAsync(Area area)
        {
            var areaModel = await _areaCollection.Find(x => x.Id == area.Id).FirstOrDefaultAsync();

            if (areaModel == null)
            {
                throw new NotFoundException("Area not found");
            }

            areaModel.Name = area.Name ?? areaModel.Name;
            areaModel.Description = area.Description ?? areaModel.Description;

            await _areaCollection.ReplaceOneAsync(x => x.Id == area.Id, areaModel);

            return _mapper.Map<Area>(areaModel);
        }

        public async Task DeleteAreaAsync(string id)
        {
            var existingArea = await _areaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            
            if (existingArea == null)
            {
                throw new NotFoundException($"Area not found");
            }

            await _areaCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
