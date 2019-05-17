﻿using System;
using Microsoft.EntityFrameworkCore;

namespace IDVNET5.Models
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
