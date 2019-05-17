using System;
namespace IDVNET5.Models
{
    public class Product
    {
        public long Id { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Img_Url { get; set; }
    }
}
