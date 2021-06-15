using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Entity
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public double Amount { get; set; }

        public string Description { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User ParentUser { get; set; }
    }
}
