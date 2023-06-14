using AutoMapper;
using MongoDB.Driver;
using ProcessFlow.Controllers.ErrorHandler;
using ProcessFlow.DataAccess;
using ProcessFlow.Models;
using ProcessFlow.Services.Interfaces;

namespace ProcessFlow.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IMongoCollection<OwnerModel> _ownerCollection;
        private readonly IMapper _mapper;

        public OwnerService(MongoContext mongoDatabaseContext, IMapper mapper)
        {
            _ownerCollection = mongoDatabaseContext.OwnerCollection;
            _mapper = mapper;
        }

        public async Task<List<Owner>> GetOwnerAsync()
        {
            var ownerModelList = await _ownerCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<Owner>>(ownerModelList);
        }

        public async Task<Owner> GetOwnerByIdAsync(string id)
        {
            var ownerModel = await _ownerCollection.Find(x => x.Id == id).SingleOrDefaultAsync();

            if (ownerModel == null)
                throw new NotFoundException("Owner not found");

            return _mapper.Map<Owner>(ownerModel);
        }

        public async Task CreateAsync(Owner owner)
        {
            var ownerModel = _mapper.Map<OwnerModel>(owner);

            if (ownerModel.Name == null)
                throw new BadRequestException("Name is required");

            await _ownerCollection.InsertOneAsync(ownerModel);
        }

        public async Task<Owner> UpdateAsync(Owner owner)
        {
            var ownerModel = await _ownerCollection.Find(x => x.Id == owner.Id).FirstOrDefaultAsync();

            if (ownerModel == null)
                throw new NotFoundException("Owner not found");

            ownerModel.Name = owner.Name ?? ownerModel.Name;

            await _ownerCollection.ReplaceOneAsync(x => x.Id == ownerModel.Id, ownerModel);

            return _mapper.Map<Owner>(ownerModel);
        }

        public async Task DeleteAsync(string id)
        {
            var result = await _ownerCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount == 0)
                throw new NotFoundException("Owner not found");
        }
    }
}
