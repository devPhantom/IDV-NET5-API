using System;
using Microsoft.AspNetCore.Mvc;
using IDVNET5.Models;

namespace IDVNET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrderController()
        {
        }
    }
}
