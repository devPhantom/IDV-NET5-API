using Microsoft.AspNetCore.Mvc;
using IDVNET5.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace IDVNET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                //string passwordHash = BCrypt.HashPassword("my password");

                // Create user if empty,
                _context.Users.Add(new User { Username = "test", Mail = "test@test.fr", Password = "test" });
                _context.SaveChanges();
            }
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [Authorize]
        // GET: api/User/5
        [HttpGet("me")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            var mail = this.User.FindFirstValue(ClaimTypes.Email);

            if(null == mail)
            {
                return NotFound();
            }

            var currentUser = await _context.Users.FirstOrDefaultAsync(user => user.Mail == mail);

            if (currentUser == null)
            {
                return NotFound();
            }

            return currentUser;
        }

        // POST:  api/User
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody]User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser([FromBody]User user)
        {
            var find = await _context.Users.FindAsync(user.Id);

            if (find == null)
            {
                return NotFound();
            }
            find.Mail = user.Mail;
            find.Username = user.Username;
            find.Password = user.Password;

            await _context.SaveChangesAsync();

            return find;
        }

        // DELETE:  api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
