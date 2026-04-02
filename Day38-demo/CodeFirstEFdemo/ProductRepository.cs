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
    internal class ProductRepository :IProductRepository
    {
        private readonly AddDbContext _context;

        public ProductRepository(AddDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.products.ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.products.FindAsync(id);

        }
        public async Task<Product> AddAsync(Product product)
        {
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task UpdateAsync(Product product)
        {
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
               _context.products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _context.products
                                 .Where(x => x.CategoryId == categoryId)
                                 .ToListAsync();
        }
    }
}
