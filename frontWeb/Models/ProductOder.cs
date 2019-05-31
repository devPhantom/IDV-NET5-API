using System;
namespace frontWeb.Models
{
    public class ProductOrder
    {
        public long Id { get; set; }
        public long IdProduct { get; set; }
        public int Quantity { get; set; }
    }
}
