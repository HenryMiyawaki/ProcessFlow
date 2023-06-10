using AutoMapper;
using MongoDB.Driver;
using ProcessFlow.DataAccess;
using ProcessFlow.Models;
using ProcessFlow.Models.Dtos;
using ProcessFlow.Services.Interfaces;

namespace ProcessFlow.Services
{
    public class SubProcessService : ISubProcessService
    {
        private readonly IMongoCollection<SubProcessModel> _subProcessCollection;
        public readonly IMapper _mapper;

        public SubProcessService(MongoContext mongoDatabaseContext, IMapper mapper)
        {
            _subProcessCollection = mongoDatabaseContext.SubProcessCollection;
            _mapper = mapper;
        }

        public async Task<List<SubProcessDto>> GetSubProcessAsync()
        {
            var subProcesseModels = await _subProcessCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<SubProcessDto>>(subProcesseModels);
        }

        public async Task CreateAsync(SubProcessDto subProcess)
        {
            try
            {
                var areaModel = _mapper.Map<SubProcessModel>(subProcess);

                await _subProcessCollection.InsertOneAsync(areaModel);
            }
            catch (Exception)
            {
                throw new Exception("bad-request");
            }
        }
    }
}
