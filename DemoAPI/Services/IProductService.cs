using DemoAPI.Dtos;

namespace DemoAPI.Services
{
    public interface IProductService
    {
        public Task<ProductDto?> GetByIdAsync(int id);
        public Task<List<ProductDto>> GetAllAsync();
        public Task<ProductDto> CreateAsync(ProductCreateDto productDto);
        public Task<ProductDto> UpdateAsync(int id, ProductCreateDto productDto);
        public Task<bool> DeleteAsync(int id);
    }
}
