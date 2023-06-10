using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProcessFlow.DataAccess;
using ProcessFlow.Models;
using ProcessFlow.Models.Dtos;
using ProcessFlow.Services.Interfaces;

namespace ProcessFlow.Services
{
    public class AreaService : IAreaService
    {
        private readonly IMongoCollection<AreaModel> _areaCollection;
        private readonly IMongoCollection<ProcessModel> _processCollection;
        private readonly IMongoCollection<SubProcessModel> _subprocessCollection;
        public readonly IMapper _mapper;

        public AreaService(MongoContext mongoDatabaseContext, IMapper mapper)
        {
            _areaCollection = mongoDatabaseContext.AreaCollection;
            _processCollection = mongoDatabaseContext.ProcessCollection;
            _subprocessCollection = mongoDatabaseContext.SubProcessCollection;
            _mapper = mapper;
        }

        public async Task<List<AreaDto>> GetAreasAsync()
        {
            var areaModels = await _areaCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<AreaDto>>(areaModels);
        }

        public async Task<AreaDto> GetAreaByIdAsync(string id) 
        {
            var areaModel = await _areaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            return _mapper.Map<AreaDto>(areaModel);
        }

        public async Task CreateAsync(AreaDto area)
        {
            try
            {
                var areaModel = _mapper.Map<AreaModel>(area);

                await _areaCollection.InsertOneAsync(areaModel);
            }
            catch (Exception)
            {
                throw new Exception("bad-request");
            }
        }

        public async Task UpdateAsync(string id, AreaDto area)
        {
            try
            {
                var areaModel = _mapper.Map<AreaModel>(area);

                await _areaCollection.ReplaceOneAsync(x => x.Id == id, areaModel);
            }
            catch(Exception)
            {
                throw new Exception("bad-request");
            }
        }

        public async Task DeleteAsync(string id)
        {
            var processes = await _processCollection.FindAsync(x => x.Area.Id == id);

            await _processCollection.DeleteManyAsync(x => x.Area.Id == id);

            if (processes != null)
            {
                await processes.ForEachAsync(x =>
                {
                    _subprocessCollection.DeleteManyAsync(y => y.Process.Id == x.Id);
                });
            }
            
            await _areaCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
