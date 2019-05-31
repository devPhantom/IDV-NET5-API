using System;
namespace IDVNET5.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Img_Url { get; set; } = "/images/no_img_available.png";
    }
}
