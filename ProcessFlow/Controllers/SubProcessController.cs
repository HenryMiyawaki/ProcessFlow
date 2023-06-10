using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessFlow.Models.Dtos;
using ProcessFlow.Services.Interfaces;

namespace ProcessFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubProcessController : ControllerBase
    {
        private readonly ISubProcessService _subProcessService;

        public SubProcessController(ISubProcessService subProcessService)
        {
            _subProcessService = subProcessService;
        }

        [HttpGet]
        public async Task<List<SubProcessDto>> GetSubProcess() =>
            await _subProcessService.GetSubProcessAsync();

        [HttpPost]
        public async Task<SubProcessDto> PostArea(SubProcessDto subProcess)
        {
            await _subProcessService.CreateAsync(subProcess);

            return subProcess;
        }
    }
}
