using System;
namespace frontWeb.Models
{
    public class HomeProductCategory
    {
        public HomeProductCategory()
        {
            ProductImgUrl = "/assets/img/no_img_available.png";   
        }

        public string Category { get; set; }
        public string ProductImgUrl { get; set; }
    }
}
