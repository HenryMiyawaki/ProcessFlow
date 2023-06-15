using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using ProcessFlow.Controllers.ErrorHandler;
using ProcessFlow.DataAccess;
using ProcessFlow.Models;
using ProcessFlow.Services.Interfaces;

namespace ProcessFlow.Services
{
    public class SubProcessService : ISubProcessService
    {
        private readonly IProcessService _processService;
        public readonly IMapper _mapper;

        public SubProcessService(
            IProcessService processService,
            IMapper mapper)
        {
            _processService = processService;
            _mapper = mapper;
        }

        public async Task<List<SubProcess>> GetSubProcessAsync(string areaName, string processId)
        {
            var process = await _processService.GetProcessByIdAsync(areaName, processId);
            
            return _mapper.Map<List<SubProcess>>(process.SubProcessModels);
        }

        public async Task<SubProcess> GetSubProcessByIdAsync(string areaName, string processId, string id)
        {
            var process = await _processService.GetProcessByIdAsync(areaName, processId);

            if (process.SubProcessModels == null)
                throw new NotFoundException("Sub process not found");

            var subProcessModel = process.SubProcessModels.SingleOrDefault(x => x.Id == id);

            if (subProcessModel == null)
                throw new NotFoundException("Sub process not found");

            return _mapper.Map<SubProcess>(subProcessModel);
        }

        public async Task<SubProcess> CreateAsync(SubProcess subProcess)
        {
            if (String.IsNullOrEmpty(subProcess.AreaName) || String.IsNullOrEmpty(subProcess.ProcessId))
                throw new BadRequestException("AreaName and processId are required");

            var process = await _processService.GetProcessByIdAsync(subProcess.AreaName, subProcess.ProcessId);
            
            subProcess.Id = ObjectId.GenerateNewId().ToString();

            if (process.SubProcessModels == null)
                process.SubProcessModels = new List<SubProcessModel>();

            process.SubProcessModels.Add(_mapper.Map<SubProcessModel>(subProcess));

            process.AreaName = subProcess.AreaName;

            await _processService.UpdateProcessAsync(process);

            return subProcess;
        }

        public async Task<SubProcess> UpdateAsync(SubProcess subProcess)
        {
            if (String.IsNullOrEmpty(subProcess.AreaName) || String.IsNullOrEmpty(subProcess.ProcessId))
                throw new BadRequestException("AreaName and processId are required");

            var process = await _processService.GetProcessByIdAsync(subProcess.AreaName, subProcess.ProcessId);

            if (process.SubProcessModels == null)
                throw new NotFoundException("Sub Process not found");

            var subProcessToUpdate = process.SubProcessModels.SingleOrDefault(x => x.Id == subProcess.Id);

            if (subProcessToUpdate == null)
                throw new NotFoundException("Sub Process not found");

            subProcessToUpdate.Name = subProcess.Name ?? subProcessToUpdate.Name;
            subProcessToUpdate.Description = subProcess.Description ?? subProcessToUpdate.Description;
            subProcessToUpdate.UsedSystems = subProcess.UsedSystems ?? subProcessToUpdate.UsedSystems;
            subProcessToUpdate.OwnersIds = subProcess.OwnersIds ?? subProcessToUpdate.OwnersIds;
            subProcessToUpdate.Documentation = subProcess.Documentation ?? subProcessToUpdate.Documentation;

            var index = process.SubProcessModels.FindIndex(x => x.Id == subProcessToUpdate.Id);
            process.SubProcessModels[index] = subProcessToUpdate;

            process.AreaName = subProcess.AreaName;

            await _processService.UpdateProcessAsync(process);
            
            return _mapper.Map<SubProcess>(subProcessToUpdate);
        }

        public async Task DeleteAsync(string areaName, string processId, string id)
        {
            var process = await _processService.GetProcessByIdAsync(areaName, processId);

            if (process.SubProcessModels == null)
                throw new NotFoundException("Sub process not found");

            var subProcessToRemove = process.SubProcessModels.SingleOrDefault(x => x.Id == id);

            if (subProcessToRemove == null)
                throw new NotFoundException("Sub process not found");

            process.SubProcessModels.Remove(subProcessToRemove);

            process.AreaName = areaName;

            await _processService.UpdateProcessAsync(process);
        }
    }
}
