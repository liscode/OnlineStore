using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public string ImageUrl { get; set; }
    }
}