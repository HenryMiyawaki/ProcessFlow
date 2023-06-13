using Microsoft.AspNetCore.Mvc;
using ProcessFlow.Models;
using ProcessFlow.Services.Interfaces;

namespace ProcessFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetArea()
        {
            var areas = await _areaService.GetAreaAsync();

            return Ok(areas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAreaById([FromRoute] string id)
        {
            var area = await _areaService.GetAreaByIdAsync(id);

            return Ok(area);
        }

        [HttpPost]
        public async Task<IActionResult> PostArea(Area area)
        {
            await _areaService.CreateAreaAsync(area);

            return Ok(area);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea([FromRoute] string id, [FromBody] Area area)
        {
            area.Id = id;
            var updatedArea = await _areaService.UpdateAreaAsync(area);

            return Ok(updatedArea);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea([FromRoute] string id)
        {
            await _areaService.DeleteAreaAsync(id);

            return Ok();
        }
    }
}
