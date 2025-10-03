using System.Reflection.Metadata.Ecma335;
using ecommerce_api.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult GetProducts()
        {
            var products = context.Products.Include(p => p.Category).ToList();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO productDto)
        {
            if(context.Products.Any(x => x.Name == productDto.Name))
            {
                return BadRequest("Product with the same name already exists.");
            }

            var category = context.Categories.Find(productDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Category doesn't exist.");
            }

            Product product = new Product
            {
                Name = productDto.Name,
                CategoryId = productDto.CategoryId,
                Price = productDto.Price,
                Description = productDto.Description,
                Stock = productDto.Stock
            };

            category.Products.Add(product);
            context.Products.Add(product);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
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
    }
}
