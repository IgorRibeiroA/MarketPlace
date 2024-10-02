using Microsoft.AspNetCore.Mvc;
using MarketPlace.Application.DTOs;
using MarketPlace.Application.Interfaces;

namespace MarketPlace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreDto>>> GetStores()
        {
            var stores = await _storeService.GetAllStoresAsync();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDto>> GetStoreById(int id)
        {
            var store = await _storeService.GetStoreByIdAsync(id);
            if (store == null)
                return NotFound();
            
            return Ok(store);
        }

        [HttpPost]
        public async Task<ActionResult<StoreDto>> CreateStore([FromBody] StoreDto storeDto)
        {
            var createdStore = await _storeService.CreateStoreAsync(storeDto);
            return CreatedAtAction(nameof(GetStoreById), new { id = createdStore.Id }, createdStore);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(int id, [FromBody] StoreDto storeDto)
        {
            if (id != storeDto.Id)
            {
                return BadRequest();
            }

            var updatedStore = await _storeService.UpdateStoreAsync(storeDto);
            if (updatedStore == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var deleted = await _storeService.DeleteStoreAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
