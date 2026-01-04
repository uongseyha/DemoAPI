using DemoAPI.Dtos;

namespace DemoAPI.Services
{
    public interface IProductService
    {
        public Task<ProductResponse?> GetByIdAsync(int id);
        public Task<List<ProductResponse>> GetAllAsync();
        public Task<ProductResponse> CreateAsync(ProductRequest productRequest);
        public Task<ProductResponse> UpdateAsync(int id, ProductRequest productRequest);
        public Task<bool> DeleteAsync(int id);
    }
}
