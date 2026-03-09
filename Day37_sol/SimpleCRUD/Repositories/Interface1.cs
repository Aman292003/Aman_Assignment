using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCRUD.Models;
namespace SimpleCRUD.Repositories
{
    internal interface Interface1
    {
        Task<List<CustomProduct>> GetAllAsync();
        Task<CustomProduct?> GetByIdAsync(int id);
        Task<CustomProduct> AddAsync(CustomProduct product);
        Task UpdateAsync(CustomProduct product);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
