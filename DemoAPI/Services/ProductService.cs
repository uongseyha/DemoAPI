using DemoAPI.Data;
using DemoAPI.Dtos;
using DemoAPI.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services
{
    public class ProductService(AppDbContext _context) : IProductService
    {
        public async Task<ProductResponse> CreateAsync(ProductRequest productRequest)
        {
            var product = productRequest.Adapt<Product>();

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product.Adapt<ProductResponse>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductResponse>> GetAllAsync()
        {
            return await _context.Products
                .OrderByDescending(p => p.UpdatedOn)
                .ProjectToType<ProductResponse>()
                .ToListAsync();
        }

        public async Task<ProductResponse?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            return product.Adapt<ProductResponse>();
        }

        public async Task<ProductResponse> UpdateAsync(int id, ProductRequest productRequest)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Title = productRequest.Title;
            product.Price = productRequest.Price;
            product.CategoryId = productRequest.CategoryId;
            product.ImageUrl = productRequest.ImageUrl;
            product.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return product.Adapt<ProductResponse>();
        }
    }
}
