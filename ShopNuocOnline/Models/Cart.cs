using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopNuocOnline.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
    }
}