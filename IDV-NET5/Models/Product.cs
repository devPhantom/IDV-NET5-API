using System;
namespace IDVNET5.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Img_Url { get; set; }
    }
}
