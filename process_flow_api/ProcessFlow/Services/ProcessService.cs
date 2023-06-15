using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using ProcessFlow.Controllers.ErrorHandler;
using ProcessFlow.DataAccess;
using ProcessFlow.Models;
using ProcessFlow.Services.Interfaces;
using System.Reflection;

namespace ProcessFlow.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IMongoCollection<AreaModel> _areaCollection;
        private readonly IAreaService _areaService;
        private readonly IMapper _mapper;

        public ProcessService(
            MongoContext mongo, 
            IAreaService areaService,
            IMapper mapper)
        {
            _areaCollection = mongo.AreaCollection;
            _areaService = areaService;
            _mapper = mapper;
        }

        public async Task<List<Process>> GetProcessAsync(string areaName)
        {
            var area = await _areaService.GetAreaByNameAsync(areaName);

            return _mapper.Map<List<Process>>(area.ProcessModels) ?? new List<Process>();
        }

        public async Task<Process> GetProcessByIdAsync(string areaId, string id)
        {
            var area = await _areaService.GetAreaByIdAsync(areaId);

            if (area.ProcessModels == null)
                throw new NotFoundException("Process not found");

            var processModel = area.ProcessModels.SingleOrDefault(x => x.Id == id);

            if (processModel == null)
                throw new NotFoundException("Process not found");

            var process = _mapper.Map<Process>(processModel);

            process.AreaName = area.Name;

            return process;
        }

        public async Task<Process> CreateProcessAsync(Process process)
        {
            if (process.Name == null || process.AreaId == null)
            {
                throw new BadRequestException("Name and AreaId are required");
            }

            var area = await _areaService.GetAreaByIdAsync(process.AreaId);

            process.Id = ObjectId.GenerateNewId().ToString();

            if (area.ProcessModels == null)
                area.ProcessModels = new List<ProcessModel>();

            area.ProcessModels.Add(_mapper.Map<ProcessModel>(process));

            await _areaCollection.ReplaceOneAsync(x => x.Id == area.Id, _mapper.Map<AreaModel>(area));

            return process;
        }

        public async Task<Process> UpdateProcessAsync(Process process)
        {
            if (process.AreaId == null)
                throw new BadRequestException("AreaId cannot be null");

            var area = await _areaService.GetAreaByIdAsync(process.AreaId);

            if (area.ProcessModels == null)
                throw new NotFoundException("Process not found");

            var processToUpdate = area.ProcessModels.SingleOrDefault(x => x.Id == process.Id);

            if(processToUpdate == null)
                throw new NotFoundException("Process not found");

            processToUpdate.Name = process.Name ?? processToUpdate.Name;
            processToUpdate.Description = process.Description ?? processToUpdate.Description;
            processToUpdate.UsedSystems = process.UsedSystems ?? processToUpdate.UsedSystems;
            processToUpdate.OwnersIds = process.OwnersIds ?? processToUpdate.OwnersIds;
            processToUpdate.SubProcessModels = process.SubProcessModels ?? processToUpdate.SubProcessModels;

            var index = area.ProcessModels.FindIndex(x => x.Id == processToUpdate.Id);
            area.ProcessModels[index] = processToUpdate;

            var areaModel = _mapper.Map<AreaModel>(area);

            await _areaCollection.ReplaceOneAsync(x => x.Id == area.Id, areaModel);

            return _mapper.Map<Process>(processToUpdate);
        }

        public async Task DeleteProcessAsync(string areaId, string id)
        {
            var area = await _areaService.GetAreaByIdAsync(areaId);

            if (area.ProcessModels == null)
                throw new NotFoundException("Process not found");

            var processToRemove = area.ProcessModels.SingleOrDefault(x => x.Id == id);

            if (processToRemove == null)
                throw new NotFoundException("Process not found");

            area.ProcessModels.Remove(processToRemove);

            await _areaCollection.ReplaceOneAsync(x => x.Id == area.Id, _mapper.Map<AreaModel>(area));
        }
    }
}
