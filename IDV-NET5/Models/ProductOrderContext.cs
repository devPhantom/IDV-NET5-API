using System;
using Microsoft.EntityFrameworkCore;

namespace IDVNET5.Models
{
    public class ProductOrderContext : DbContext
    {
        public ProductOrderContext(DbContextOptions<ProductOrderContext> options)
            : base(options)
        {
        }

        public DbSet<ProductOrder> ProductOrders { get; set; }
    }
}
