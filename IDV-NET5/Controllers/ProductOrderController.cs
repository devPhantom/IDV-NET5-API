using System;
using Microsoft.AspNetCore.Mvc;
using IDVNET5.Models;

namespace IDVNET5.Controllers
{
    public class ProductOrderController : ControllerBase
    {
        private readonly ProductOrderContext _context;

        public ProductOrderController()
        {
        }
    }
}
