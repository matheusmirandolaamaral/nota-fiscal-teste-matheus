using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nota_fiscal_teste.Model;
using nota_fiscal_teste.Services;
using Serilog;

namespace nota_fiscal_teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            _logger.LogInformation("Finding all products");
            return Ok(_productService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            _logger.LogInformation("fetching product with ID {id}", id);
            var product = _productService.FindById(id);
            if (product == null)
            {
                _logger.LogWarning("Product with ID {id} not found", id);
                return NotFound();

            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            _logger.LogInformation("Creating new product with name {name}", product.Name);

            var createdProduct = _productService.Create(product);
            if (createdProduct == null)
            {
                _logger.LogError("Failed to create product with name {name}", product.Name);
                return NotFound();
            }
            return Ok(createdProduct);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            _logger.LogInformation("Updating product with ID {id}", product.Id);
            var updatedProduct = _productService.Update(product);
            if (updatedProduct == null)
            {
                _logger.LogError("Product with ID {id} not found for update", product.Id);
                return NotFound();
            }
            _logger.LogDebug("Product with ID {id} updated successfully", product.Id);
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting product with ID {id}", id);
            _productService.Delete(id);
             _logger.LogDebug("Product with ID {id} deleted successfully", id);
            return NoContent();
        }
    }
}
