using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductTask.Models;

namespace ProductTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;

        public ProductController(IProduct productService)
        {
             _productService = productService;
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if(product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpPost]

        public async Task<ActionResult<Product>> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var added = await _productService.AddProductAsync(product);
            return Ok(added);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Product>> Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pro = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
            };

            var updated =await _productService.UpdateProductAsync(pro);
            return Ok(updated);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Product>> Delete(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);

            if(deleted== null)
            {
                return NotFound("Product not found to delete");
            }

            return Ok(deleted);
        }
    }
}
