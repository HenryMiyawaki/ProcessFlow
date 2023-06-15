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

        [HttpGet("{areaId}")]
        public async Task<IActionResult> GetProcess([FromRoute] string areaId)
        {
            var processes = await _processService.GetProcessAsync(areaId);

            return Ok(processes);
        }

        [HttpGet("{areaId}/{id}")]
        public async Task<IActionResult> GetProcessById([FromRoute] string areaId, [FromRoute] string id)
        {
            var process = await _processService.GetProcessByIdAsync(areaId, id);

            return Ok(process);
        }

        [HttpPost("{areaId}")]
        public async Task<IActionResult> PostProcess([FromRoute] string areaId, Process process)
        {
            process.AreaId = areaId;
            await _processService.CreateProcessAsync(process);

            return Ok(process);
        }

        [HttpPut("{areaId}/{id}")]
        public async Task<IActionResult> PutProcess([FromRoute] string areaId, [FromRoute] string id, [FromBody] Process process)
        {
            process.Id = id;
            process.AreaId = areaId;

            var processReturn = await _processService.UpdateProcessAsync(process);

            return Ok(processReturn);
        }

        [HttpDelete("{areaId}/{id}")]
        public async Task<IActionResult> DeleteProcess([FromRoute] string areaId, [FromRoute] string id)
        {
            await _processService.DeleteProcessAsync(areaId, id);

            return Ok();
        }
    }
}
