using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Models.Products
{
    public class CreateProductVM
    {
        [Required(ErrorMessage = "*This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "*This field is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "*This field is required")]
        public double Amount { get; set; }
    }
}
