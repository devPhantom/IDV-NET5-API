using System;
using Microsoft.AspNetCore.Mvc;
using IDVNET5.Models;
using System.Threading.Tasks;
using System.Linq;

namespace IDVNET5.Controllers
{
    public class ProductOrderController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductOrderController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ProductOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOrder>> GetProductOrder(long id)
        {
            var productOrder = await _context.ProductOrders.FindAsync(id);

            if (productOrder == null)
            {
                return NotFound();
            }

            return productOrder;
        }

        // POST:  api/ProductOrder
        [HttpPost]
        public async Task<ActionResult<ProductOrder>> CreateProductOrder([FromBody]ProductOrder productOrder)
        {
            _context.ProductOrders.Add(productOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductOrder), new { id = productOrder.Id }, productOrder);
        }

        // DELETE:  api/ProductOrder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductOrder(long id)
        {
            var productOrder = await _context.ProductOrders.FindAsync(id);

            if (productOrder == null)
            {
                return NotFound();
            }

            _context.ProductOrders.Remove(productOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
