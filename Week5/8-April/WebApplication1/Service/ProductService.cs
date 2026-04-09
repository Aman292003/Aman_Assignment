using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var result = await _context.products.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var result = await _context.products.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            return result;

        }

        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _context.products.FindAsync(id);

            if (existingProduct == null)
            {
                return null; // not found
            }

            // Update fields (IMPORTANT)
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.Stock = product.Stock;
            // add other fields as needed

            // Save changes
            await _context.SaveChangesAsync();

            return existingProduct;
        }
    }
}
