using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IDVNET5.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IDVNET5.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AuthController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string mail, string password)
        {
        
            var user = GetUserFromMail(mail);

            if(null == user)
            {
                return BadRequest();
            }

            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, user.Mail),
            }, 
            "Cookies");

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await Request.HttpContext.SignInAsync("Cookies", claimsPrincipal);

            return NoContent();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return NoContent();
        }

        private User GetUserFromMail(string mail)
        {
            return _context.Users.FirstOrDefault(user => user.Mail == mail);
        }

        private bool IsValidUsernameAndPasswod(string username, string password)
        {
            return true;
        }
    }
}
