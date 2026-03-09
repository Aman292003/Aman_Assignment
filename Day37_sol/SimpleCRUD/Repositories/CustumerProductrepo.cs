using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Repositories
{
    internal class CustumerProductrepo : Interface1
    {
        private readonly NorthWindContext _context;
        public CustumerProductrepo(NorthWindContext context)
        {
            _context = context;
        }
        public async Task<CustomProduct> AddAsync(CustomProduct product)
        {

            await _context.CustomProducts.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.CustomProducts
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                _context.CustomProducts.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CustomProduct>> GetAllAsync()
        {
            return await _context.CustomProducts.ToListAsync();                
        }

        public async Task<CustomProduct?> GetByIdAsync(int id)
        {
            return await _context.CustomProducts.FindAsync(id);
            
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomProduct product)
        {
            _context.CustomProducts.Update(product);
            await _context.SaveChangesAsync();

        }
    }
}
