using DemoAPI.Dtos;
using DemoAPI.Entities;

namespace DemoAPI.Services
{
    public interface ICategoryService
    {
        public Task<CategoryResponse?> GetByIdAsync(int id);
        public Task<List<CategoryResponse>> GetAllAsync();
    }
}
