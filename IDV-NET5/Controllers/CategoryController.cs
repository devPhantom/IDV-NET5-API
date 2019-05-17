﻿using System;
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
        private readonly CategoryContext _context;

        public CategoryController(CategoryContext context)
        {
            _context = context;

            if (_context.Categories.Count() == 0)
            {
                // Create list of Products if collection is empty,
                _context.Categories.Add(new Category { Name = "MacBook" });
                _context.Categories.Add(new Category { Name = "Iphone" });
                _context.Categories.Add(new Category { Name = "Ipad" });
                _context.Categories.Add(new Category { Name = "Montre" });
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
    }
}
