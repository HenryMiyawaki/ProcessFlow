using Microsoft.AspNetCore.Mvc;
using ProcessFlow.Models;
using ProcessFlow.Services.Interfaces;

namespace ProcessFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController (IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<List<OwnerModel>> GetOwner() =>
            await _ownerService.GetOwnerAsync();

        [HttpGet("{id}")]
        public async Task<OwnerModel> GetOwnerById([FromRoute] string id) =>
            await _ownerService.GetOwnerByIdAsync(id);

        [HttpPost]
        public async Task<OwnerModel> PostOwner(OwnerModel owner)
        {
            await _ownerService.CreateAsync(owner);

            return owner;
        }

        [HttpPut("{id}")]
        public async Task PutOwner([FromRoute] string id, [FromBody] OwnerModel owner) =>
            await _ownerService.UpdateAsync(id, owner);

        [HttpDelete("{id}")]
        public async Task DeleteOwner([FromRoute] string id) =>
            await _ownerService.DeleteAsync(id);
    }
}
