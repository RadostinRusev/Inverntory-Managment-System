using Inverntory_Managment_System.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Models.Products
{
    public class EditVM { 
    public int Id { get; set; }

    public int UserId { get; set; }

    [Required(ErrorMessage = "*This field is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "*This field is required")]
    public double Price { get; set; }

    [Required(ErrorMessage = "*This field is required")]
    public double Amount { get; set; }
        [Required(ErrorMessage = "*This field is required")]
        public string Description { get; set; }

        public EditingHistory editing { get; set; }

       public string OldName { get; set; }
        public double OldPrice { get; set; }
        public string OldDescription { get; set; }
        public double OldAmount { get; set; }
        public int ProductId { get; set; }
    }
}
