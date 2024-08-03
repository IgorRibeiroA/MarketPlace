using MarketPlace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MarketPlace.Application.UseCases;
using System;
using System.Threading.Tasks;

namespace MarketPlace.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly CreateStore _createStore;

        public StoreController(CreateStore createStore)
        {
            _createStore = createStore;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Store store)
        {
            var result = await _createStore.ExecuteAsync(store);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
