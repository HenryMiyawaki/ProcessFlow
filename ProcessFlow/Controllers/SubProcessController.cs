using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessFlow.Models;
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

        [HttpGet("{areaId}/{processId}")]
        public async Task<IActionResult> GetSubProcess([FromRoute] string areaId, [FromRoute] string processId)
        {
            var subProcesses = await _subProcessService.GetSubProcessAsync(areaId, processId);

            return Ok(subProcesses);
        }

        [HttpGet("{areaId}/{processId}/{id}")]
        public async Task<IActionResult> GetSubProcess(
            [FromRoute] string areaId, 
            [FromRoute] string processId, 
            [FromRoute] string id)
        {

            var subProcess = await _subProcessService.GetSubProcessByIdAsync(areaId, processId, id);

            return Ok(subProcess);
        }

        [HttpPost("{areaId}/{processId}")]
        public async Task<IActionResult> PostSubProcess(
            [FromRoute] string areaId, 
            [FromRoute] string processId, 
            SubProcess subProcess)
        {
            subProcess.AreaId = areaId;
            subProcess.ProcessId = processId;

            await _subProcessService.CreateAsync(subProcess);

            return Ok(subProcess);
        }

        [HttpPut("{areaId}/{processId}/{id}")]
        public async Task<IActionResult> PutSubProcess(
            [FromRoute] string areaId, 
            [FromRoute] string processId, 
            [FromRoute] string id, 
            [FromBody] SubProcess subProcess)
        {
            subProcess.AreaId = areaId;
            subProcess.ProcessId = processId;
            subProcess.Id = id;

            var subProcessReturn = await _subProcessService.UpdateAsync(subProcess);

            return Ok(subProcessReturn);
        }

        [HttpDelete("{areaId}/{processId}/{id}")]
        public async Task<IActionResult> DeleteSubProcess(
            [FromRoute] string areaId,
            [FromRoute] string processId,
            [FromRoute] string id)
        {
            await _subProcessService.DeleteAsync(areaId, processId, id);

            return Ok();
        }
    }
}
