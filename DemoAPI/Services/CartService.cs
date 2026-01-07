using DemoAPI.Data;
using DemoAPI.Dtos;
using DemoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services
{
    public class CartService(AppDbContext _context) : ICartService
    {
        public async Task<CartRecord> CreateCartAsync()
        {
            var cart = new Cart();
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return new CartRecord(cart.Id,cart.UserId, new());
        }

        public async Task<CartRecord?> GetCartAsync(int cartId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.Id == cartId);

            if (cart == null) return null;

            return new CartRecord(
                cart.Id,
                cart.UserId,
                cart.CartItems.Select(ci =>
                    new CartItemRecord(
                        ci.Id,
                        ci.ProductId,
                        ci.Product.Title,
                        ci.Product.Price,
                        ci.Quantity,
                        ci.Product.ImageUrl
                    )).ToList()
            );
        }

        public async Task<bool> AddItemAsync(int cartId, AddCartItemRecord addCartItemRecord)
        {
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart == null) return false;

            var item = await _context.CartItems
                .FirstOrDefaultAsync(ci =>
                    ci.CartId == cartId && ci.ProductId == addCartItemRecord.ProductId);

            if (item == null)
            {
                item = new CartItem
                {
                    CartId = cartId,
                    ProductId = addCartItemRecord.ProductId,
                    Quantity = addCartItemRecord.Quantity
                };
                _context.CartItems.Add(item);
            }
            else
            {
                item.Quantity += addCartItemRecord.Quantity;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveItemAsync(int cartId, int itemId)
        {
            var item = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.Id == itemId && ci.CartId == cartId);

            if (item == null) return false;

            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
