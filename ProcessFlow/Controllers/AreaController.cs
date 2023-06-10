using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessFlow.Models;
using ProcessFlow.Models.Dtos;
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
        public async Task<List<AreaDto>> GetAreas() =>
            await _areaService.GetAreasAsync();

        [HttpGet("{id}")]
        public async Task<AreaDto> PostArea([FromRoute] string id) =>
            await _areaService.GetAreaByIdAsync(id);

        [HttpPost]
        public async Task<AreaDto> PostArea(AreaDto area)
        {
            await _areaService.CreateAsync(area);

            return area;
        }

        [HttpPut("{id}")]
        public async Task PutArea([FromRoute] string id, [FromBody] AreaDto area) =>
            await _areaService.UpdateAsync(id, area);

        [HttpDelete("{id}")]
        public async Task DeleteArea([FromRoute] string id) =>
            await _areaService.DeleteAsync(id);
    }
}
