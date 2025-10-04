using ecommerce_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ECommerceDbContext context;
        public CategoryController(ECommerceDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = context.Categories.Include(c => c.Products).ToList();
           
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(long id)
        {
            var category = context.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            if (context.Categories.Any(x => x.Name == category.Name))
            {
                return BadRequest("Category with the same name already exists.");
            }
            context.Categories.Add(category);
            context.SaveChanges();
            return CreatedAtAction(nameof(CreateCategory), new { id = category.Id }, category);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(long id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }
            if (context.Products.Any(p => p.CategoryId == id))
            {
                return BadRequest("Cannot delete category with associated products.");
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(long id, [FromBody] Category updatedCategory)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }
            if (context.Categories.Any(x => x.Name == updatedCategory.Name && x.Id != id))
            {
                return BadRequest("Another category with the same name already exists.");
            }
            category.Name = updatedCategory.Name;
            context.SaveChanges();
            return NoContent();
        }


    }
}
