﻿using System;
using Microsoft.EntityFrameworkCore;

namespace IDVNET5.Models
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
