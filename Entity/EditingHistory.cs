using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Entity
{
    public class EditingHistory:BaseEntity
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string OldName { get; set; }
        public double OldAmount { get; set; }
        public string OldDescription { get; set; }
        public double OldPrice { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User ParentUser { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product ParentProduct { get; set; }
    }
}
