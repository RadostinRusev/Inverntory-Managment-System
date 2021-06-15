using Inverntory_Managment_System.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Models.Products
{
    public class ProductVM
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }

        public string Name { get; set; }
        public string Amount { get; set; }
        public string PriceUp { get; set; }
        public string PriceDown { get; set; }
        public List<Product> Items { get; set; }
    }
}
