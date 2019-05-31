using System;
using Microsoft.AspNetCore.Mvc;
using IDVNET5.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IDVNET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CategoryController(DatabaseContext context)
        {
            _context = context;

            if (_context.Categories.Count() == 0)
            {
                // Create list of Products if collection is empty,
                _context.Categories.Add(new Category { Name = "MacBook", Img_Url = "/images/macbook.jpg" });
                _context.Categories.Add(new Category { Name = "Iphone", Img_Url = "/images/iphone.jpeg" });
                _context.Categories.Add(new Category { Name = "Ipad", Img_Url = "/images/ipad.jpeg" });
                _context.Categories.Add(new Category { Name = "Montre", Img_Url = "/images/applewatch.jpeg" });
                _context.SaveChanges();
            }
        }


        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(long id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        // DELETE:  api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
