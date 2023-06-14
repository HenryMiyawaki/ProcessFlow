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

        public async Task<List<SubProcess>> GetSubProcessAsync(string areaId, string processId)
        {
            var process = await _processService.GetProcessByIdAsync(areaId, processId);
            
            return _mapper.Map<List<SubProcess>>(process.SubProcessModels);
        }

        public async Task<SubProcess> GetSubProcessByIdAsync(string areaId, string processId, string id)
        {
            var process = await _processService.GetProcessByIdAsync(areaId, processId);

            if (process.SubProcessModels == null)
                throw new NotFoundException("Sub process not found");

            var subProcessModel = process.SubProcessModels.SingleOrDefault(x => x.Id == id);

            if (subProcessModel == null)
                throw new NotFoundException("Sub process not found");

            return _mapper.Map<SubProcess>(subProcessModel);
        }

        public async Task<SubProcess> CreateAsync(SubProcess subProcess)
        {
            if (String.IsNullOrEmpty(subProcess.AreaId) || String.IsNullOrEmpty(subProcess.ProcessId))
                throw new BadRequestException("AreaId and processId are required");

            var process = await _processService.GetProcessByIdAsync(subProcess.AreaId, subProcess.ProcessId);
            
            subProcess.Id = ObjectId.GenerateNewId().ToString();

            if (process.SubProcessModels == null)
                process.SubProcessModels = new List<SubProcessModel>();

            process.SubProcessModels.Add(_mapper.Map<SubProcessModel>(subProcess));

            process.AreaId = subProcess.AreaId;

            await _processService.UpdateProcessAsync(process);

            return subProcess;
        }

        public async Task<SubProcess> UpdateAsync(SubProcess subProcess)
        {
            if (String.IsNullOrEmpty(subProcess.AreaId) || String.IsNullOrEmpty(subProcess.ProcessId))
                throw new BadRequestException("AreaId and processId are required");

            var process = await _processService.GetProcessByIdAsync(subProcess.AreaId, subProcess.ProcessId);

            if (process.SubProcessModels == null)
                throw new NotFoundException("Sub Process not found");

            var subProcessToUpdate = process.SubProcessModels.SingleOrDefault(x => x.Id == subProcess.Id);

            if (subProcessToUpdate == null)
                throw new NotFoundException("Sub Process not found");

            subProcessToUpdate.Name = subProcess.Name ?? subProcessToUpdate.Name;
            subProcessToUpdate.Description = subProcess.Description ?? subProcessToUpdate.Description;
            subProcessToUpdate.UsedSystems = subProcess.UsedSystems ?? subProcessToUpdate.UsedSystems;
            subProcessToUpdate.Owners = subProcess.Owners ?? subProcessToUpdate.Owners;
            subProcessToUpdate.Documentation = subProcess.Documentation ?? subProcessToUpdate.Documentation;

            var index = process.SubProcessModels.FindIndex(x => x.Id == subProcessToUpdate.Id);
            process.SubProcessModels[index] = subProcessToUpdate;

            process.AreaId = subProcess.AreaId;

            await _processService.UpdateProcessAsync(process);
            
            return _mapper.Map<SubProcess>(subProcessToUpdate);
        }

        public async Task DeleteAsync(string areaId, string processId, string id)
        {
            var process = await _processService.GetProcessByIdAsync(areaId, processId);

            if (process.SubProcessModels == null)
                throw new NotFoundException("Sub process not found");

            var subProcessToRemove = process.SubProcessModels.SingleOrDefault(x => x.Id == id);

            if (subProcessToRemove == null)
                throw new NotFoundException("Sub process not found");

            process.SubProcessModels.Remove(subProcessToRemove);

            process.AreaId = areaId;

            await _processService.UpdateProcessAsync(process);
        }
    }
}
