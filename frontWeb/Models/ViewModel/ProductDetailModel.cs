using System;
using System.Collections.Generic;

namespace frontWeb.Models.ViewModel
{
    public class ProductDetailModel
    {
        public ProductDetailModel()
        {
            RelatedProducts = new List<Product>();
        }

        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public string CategoryName { get; set; }
    }
}
