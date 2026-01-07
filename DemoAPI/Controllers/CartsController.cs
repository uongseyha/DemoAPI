using DemoAPI.Entities;
using DemoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(ICartService _cartService) : ControllerBase
    {
        [HttpPost]
        public async Task<CartRecord> Create()
        => await _cartService.CreateCartAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<CartRecord>> Get(int id)
        {
            var cart = await _cartService.GetCartAsync(id);
            return cart == null ? NotFound() : Ok(cart);
        }

        [HttpPost("{cartId}/items")]
        public async Task<IActionResult> AddItem(int cartId, AddCartItemRecord addCartItemRecord)
        {
            return await _cartService.AddItemAsync(cartId, addCartItemRecord)
                ? NoContent()
                : NotFound();
        }

        [HttpDelete("{cartId}/items/{itemId}")]
        public async Task<IActionResult> RemoveItem(int cartId, int itemId)
        {
            return await _cartService.RemoveItemAsync(cartId, itemId)
                ? NoContent()
                : NotFound();
        }
    }
}
