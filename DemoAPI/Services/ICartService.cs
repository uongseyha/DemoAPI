using DemoAPI.Dtos;
using DemoAPI.Entities;

namespace DemoAPI.Services
{
    public interface ICartService
    {
        Task<CartRecord> CreateCartAsync();
        Task<CartRecord?> GetCartAsync(int cartId);
        Task<bool> AddItemAsync(int cartId, AddCartItemRecord addCartItemRecord);
        Task<bool> RemoveItemAsync(int cartId, int itemId);
    }

}
