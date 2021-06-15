using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Models.Home
{
    public class LoginVM
    {
        [Required(ErrorMessage = "field required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "field required")]
        public string Password { get; set; }
    }
}
