using System;
using System.Collections.Generic;

namespace IDVNET5.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public List<ProductOrder> ProductList { get; set; }
    }
}
