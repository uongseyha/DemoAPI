using DemoAPI.Data;
using DemoAPI.Dtos;
using DemoAPI.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services
{
    public class CategoryService(AppDbContext _context): ICategoryService
    {
        public async Task<CategoryResponse?> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;

            return category.Adapt<CategoryResponse>();
        }

        public async Task<List<CategoryResponse>> GetAllAsync()
        {
            return await _context.Categories
                .ProjectToType<CategoryResponse>()
                .ToListAsync();
        }
    }
}
