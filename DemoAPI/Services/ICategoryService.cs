using DemoAPI.Dtos;
using DemoAPI.Entities;

namespace DemoAPI.Services
{
    public interface ICategoryService
    {
        public Task<CategoryDto?> GetByIdAsync(int id);
        public Task<List<CategoryDto>> GetAllAsync();
    }
}
