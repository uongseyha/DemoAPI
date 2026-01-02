using DemoAPI.Data;
using DemoAPI.Dtos;
using DemoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Services
{
    public class ProductService(AppDbContext _context) : IProductService
    {
        public async Task<ProductDto> CreateAsync(ProductCreateDto productDto)
        {
            var product = new Product
            {
                Title = productDto.Title,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                ImageUrl = productDto.ImageUrl,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Price = product.Price,
                Title = product.Title,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            return await _context.Products.OrderByDescending(p => p.UpdatedOn).Select(u => new ProductDto
            {
                Id = u.Id,
                Title = u.Title,
                Price = u.Price,
                CategoryId = u.CategoryId,
                ImageUrl = u.ImageUrl,
                IsProtected = u.IsProtected
            })
            .ToListAsync();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl,
                IsProtected = product.IsProtected
            };
        }

        public async Task<ProductDto> UpdateAsync(int id, ProductCreateDto productDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Title = productDto.Title;
            product.Price = productDto.Price;
            product.CategoryId = productDto.CategoryId;
            product.ImageUrl = productDto.ImageUrl;
            product.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl
            };
        }
    }
}
