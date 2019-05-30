using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDVNET5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDVNET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductController(DatabaseContext context)
        {
            _context = context;

            if (_context.Products.Count() == 0)
            {
                // Create list of Products if collection is empty,
                _context.Products.Add(new Product { Name = "Macbook 12\" 256 Go", IdCategory = 1, Price = 1500 });
                _context.Products.Add(new Product { Name = "Macbook 12\" 512 Go", IdCategory = 1, Price = 1800 });
                _context.Products.Add(new Product { Name = "Macbook Air 13\" 128 Go", IdCategory = 1, Price = 1350 });
                _context.Products.Add(new Product { Name = "Macbook Air 13\" 256 Go", IdCategory = 1, Price = 1600 });
                _context.Products.Add(new Product { Name = "Macbook Pro 13\" 128 Go", IdCategory = 1, Price = 1500 });
                _context.Products.Add(new Product { Name = "Macbook Pro 13\" 256 Go", IdCategory = 1, Price = 1750 });
                _context.Products.Add(new Product { Name = "Macbook Pro 13\" 512 Go", IdCategory = 1, Price = 1999 });
                _context.Products.Add(new Product { Name = "iPad Pro 11\" 64Go", IdCategory = 3, Price = 899 });
                _context.Products.Add(new Product { Name = "iPad Pro 11\" 256Go", IdCategory = 3, Price = 1069 });
                _context.Products.Add(new Product { Name = "iPad Pro 11\" 512Go", IdCategory = 3, Price = 1289 });
                _context.Products.Add(new Product { Name = "iPhone 7 32 Go", IdCategory = 2, Price = 529 });
                _context.Products.Add(new Product { Name = "iPhone 7 128 Go", IdCategory = 2, Price = 637 });
                _context.Products.Add(new Product { Name = "iPhone 8 64 Go", IdCategory = 2, Price = 685 });
                _context.Products.Add(new Product { Name = "iPhone 8 256 Go", IdCategory = 2, Price = 857 });
                _context.Products.Add(new Product { Name = "iPhone Xs 64 Go", IdCategory = 2, Price = 1155 });
                _context.Products.Add(new Product { Name = "iPhone Xs 256 Go", IdCategory = 2, Price = 1327 });
                _context.Products.Add(new Product { Name = "iPhone Xs 512 Go", IdCategory = 2, Price = 1557 });
                _context.Products.Add(new Product { Name = "iPhone Xr 64 Go", IdCategory = 2, Price = 855 });
                _context.Products.Add(new Product { Name = "iPhone Xr 128 Go", IdCategory = 2, Price = 917 });
                _context.Products.Add(new Product { Name = "iPhone Xr 256 Go", IdCategory = 2, Price = 1027 });
                _context.Products.Add(new Product { Name = "Apple Watch Serie 3 Bracelet Sport GPS", IdCategory = 4, Price = 299 });
                _context.Products.Add(new Product { Name = "Apple Watch Serie 3 Bracelet Sport GPS + Cellular", IdCategory = 4, Price = 399 });
                _context.Products.Add(new Product { Name = "Apple Watch Serie 4 Bracelet Sport GPS", IdCategory = 4, Price = 429 });
                _context.Products.Add(new Product { Name = "Apple Watch Serie 4 Bracelet Sport GPS + Cellular", IdCategory = 4, Price = 529 });
                _context.SaveChanges();
            }
        }


        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int offset = 0, int limit = 50)
        {
            var products = await _context.Products.OrderBy(x => x.Id).Skip(offset).Take(limit).ToListAsync();

            return products;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);


            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST:  api/Product
        [HttpPost]
        public async Task<ActionResult<Order>> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // DELETE:  api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
