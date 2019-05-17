using System;
using Microsoft.AspNetCore.Mvc;
using IDVNET5.Models;

namespace IDVNET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController()
        {
        }
    }
}
