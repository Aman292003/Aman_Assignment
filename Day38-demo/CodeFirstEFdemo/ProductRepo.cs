using CodeFirstEFdemo.Data;
using CodeFirstEFdemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFdemo
{
    internal class ProductRepo : IProductRepository
    {
        private readonly AddDbContext _context;
        public ProductRepo(AddDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            var result = await _context.products.FromSqlRaw($"EXEC InsertProduct" +
               $" {product.Name},{product.Price},{product.CategoryId}").ToListAsync();
            return result.First();
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC DeleteProduct {id}");
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.products
                .FromSqlRaw("EXEC GetAllProducts").ToListAsync();
        }

        public Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await _context.products
                .FromSqlRaw("EXEC GetProductById @id ={0}", id).FirstOrDefaultAsync();

            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC UpdateProduct {product.Id}," +
               $"{product.Name},{product.Price},{product.CategoryId} ");
            Console.WriteLine("Product added ");
        }
    }
}
