//using AutoMapper;
//using MongoDB.Driver;
//using ProcessFlow.DataAccess;
//using ProcessFlow.Models;
//using ProcessFlow.Models.Dtos;
//using ProcessFlow.Services.Interfaces;

//namespace ProcessFlow.Services
//{
//    public class OwnerService : IOwnerService
//    {
//        private readonly IMongoCollection<OwnerModel> _ownerCollection;
//        private readonly IMapper _mapper;

//        public OwnerService(MongoContext mongoDatabaseContext, IMapper mapper)
//        {
//            _ownerCollection = mongoDatabaseContext.OwnerCollection;
//            _mapper = mapper;
//        }

//        public async Task<List<OwnerDto>> GetOwnerAsync()
//        {
//            try
//            {
//                var ownerModelList = await _ownerCollection.Find(x => true).ToListAsync();

//                return _mapper.Map<List<OwnerDto>>(ownerModelList);
//            }
//            catch (Exception)
//            {
//                throw new Exception("bad-request");
//            }
//        }

//        public async Task<OwnerDto> GetOwnerByIdAsync(string id)
//        {
//            try
//            {
//                var ownerModel = await _ownerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

//                return _mapper.Map<OwnerDto>(ownerModel);
//            }
//            catch (Exception)
//            {
//                throw new Exception("bad-request");
//            }
//        }

//        public async Task CreateAsync(OwnerDto ownerDto) 
//        {
//            try
//            {
//                var ownerModel = _mapper.Map<OwnerModel>(ownerDto);

//                await _ownerCollection.InsertOneAsync(ownerModel);
//            }
//            catch (Exception)
//            {
//                throw new Exception("bad-request");
//            }
//        }

//        public async Task UpdateAsync(string id, OwnerDto ownerDto)
//        {
//            try
//            {
//                var ownerModel = _mapper.Map<OwnerModel>(ownerDto);

//                await _ownerCollection.ReplaceOneAsync(x => x.Id == id, ownerModel);
//            }
//            catch (Exception)
//            {
//                throw new Exception("bad-request");
//            }
//        }

//        public async Task DeleteAsync(string id)
//        {
//            await _ownerCollection.DeleteOneAsync(id);
//        }
//    }
//}
