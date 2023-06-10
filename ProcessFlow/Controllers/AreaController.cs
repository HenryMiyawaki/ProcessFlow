using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessFlow.Models;
using ProcessFlow.Services;

namespace ProcessFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly AreaService _areaService;

        public AreaController(AreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<List<AreaModel>> GetAreas() =>
            await _areaService.GetAreasAsync();

        [HttpPost]
        public async Task<AreaModel> PostArea(AreaModel area)
        {
            await _areaService.CreateAsync(area);

            return area;
        }
    }
}
