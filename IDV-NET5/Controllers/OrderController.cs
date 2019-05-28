using System;
using Microsoft.AspNetCore.Mvc;
using IDVNET5.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IDVNET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OrderController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(long id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // GET: api/Order/user/5
        [HttpGet("/user/{id}")]
        public async Task<ActionResult<Order>> GetOrderByIdUser(long id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.IdUser == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST:  api/Order
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // DELETE:  api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
