using ecommerce_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ECommerceDbContext context;

        public ProductController(ECommerceDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] long? categoryId, [FromQuery] string? productName)
        {

            var query = context.Products.AsQueryable();
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(productName)) {
                query = query.Where(p => p.Name != null && p.Name.Contains(productName));
            }
            
            return Ok(query.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(long id)
        {
            var product = context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] List<ProductDTO> products)
        {
            if(products.Count > 0)
            {
                foreach (var item in products)
                {

                    if (context.Products.Any(p => p.Name == item.Name))
                    {
                        return BadRequest($"Product with name {item.Name} already exists.");
                    }

                    Product product = new Product();
                    product.Name = item.Name;
                    product.CategoryId = item.CategoryId;
                    product.Description = item.Description;
                    product.Price = item.Price;
                    product.Stock = item.Stock;
                    await context.Products.AddAsync(product);
                }
            } else
            {
                return NoContent();
            }

            await context.SaveChangesAsync();
            return Ok("Products created.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(long id)
        {
            var product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(long id, [FromBody] ProductDTO productDTO)
        {
            var product = context.Products.Find(id);
            if (product == null) { return NotFound("Product not found."); }
            var category = context.Categories.Find(productDTO.CategoryId);
            if (category == null) { return BadRequest("Category doesn't exist."); }

            product.Name = productDTO.Name;
            product.CategoryId = productDTO.CategoryId;
            product.Price = productDTO.Price;
            product.Description = productDTO.Description;
            product.Stock = productDTO.Stock;
            context.SaveChanges();
            return NoContent();
        }

       

        
    }
}
