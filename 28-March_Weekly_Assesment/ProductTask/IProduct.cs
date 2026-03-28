using ProductTask.Models;

namespace ProductTask
{
    public interface IProduct
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product product);
        Task<Product?> DeleteProductAsync(int id);
    
    }
}
