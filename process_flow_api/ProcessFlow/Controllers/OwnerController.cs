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
        public async Task<IActionResult> GetOwner()
        {
            var owners = await _ownerService.GetOwnerAsync();

            return Ok(owners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwnerById([FromRoute] string id)
        {
            var owner = await _ownerService.GetOwnerByIdAsync(id);

            return Ok(owner);
        }

        [HttpPost]
        public async Task<Owner> PostOwner(Owner owner)
        {
            await _ownerService.CreateAsync(owner);

            return owner;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner([FromRoute] string id, [FromBody] Owner owner)
        {
            owner.Id = id;
            var updatedArea = await _ownerService.UpdateAsync(owner);

            return Ok(updatedArea);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner([FromRoute] string id)
        {
            await _ownerService.DeleteAsync(id);

            return Ok();
        }
    }
}
