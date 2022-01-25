using LibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // PUT: api/Cart/{userId}/{itemId}
        [HttpPut("{userId}/{itemId}")]
        public async Task<IActionResult> AddItem(Guid userId, Guid itemId)
        {
            if (userId.Equals(null) || itemId.Equals(null))
            {
                return BadRequest();
            }

            var success = await _cartService.AddItem(userId, itemId);
            if (!success)
            {
                return NotFound();
            }

            return Ok(success);
        }

    }
}