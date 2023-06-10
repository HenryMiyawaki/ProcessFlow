using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessFlow.Models;
using ProcessFlow.Services.Interfaces;

namespace ProcessFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        [HttpGet]
        public async Task<List<ProcessModel>> GetProcess() =>
            await _processService.GetProcessAsync();

        [HttpPost]
        public async Task<ProcessModel> PostProcess(ProcessModel process)
        {
            await _processService.CreateAsync(process);

            return process;
        }
    }
}
