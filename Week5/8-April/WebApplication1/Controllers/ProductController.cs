using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        // Constructor Injection
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        // ✅ Get Product By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // ✅ Create Product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var createdProduct = await _productService.CreateProductAsync(product);
            return Ok(createdProduct);
        }

        // ✅ Update Product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            var updatedProduct = await _productService.UpdateProductAsync(id, product);

            if (updatedProduct == null)
                return NotFound();

            return Ok(updatedProduct);
        }

        // ✅ Delete Product
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var isDeleted = await _productService.DeleteProductAsync(id);

            if (!isDeleted)
                return NotFound();

            return Ok("Product deleted successfully");
        }
    }
}
