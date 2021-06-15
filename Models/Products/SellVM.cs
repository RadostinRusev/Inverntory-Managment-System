using Inverntory_Managment_System.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Models.Products
{
    public class SellVM
    {
        public User user { get; set; }
        public Product product { get; set; }
        public int Id { get; set; }

        public int UserId { get; set; }

       
        public string Name { get; set; }

      public double overallPrice { get; set; }
        public double Price { get; set; }
      
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
