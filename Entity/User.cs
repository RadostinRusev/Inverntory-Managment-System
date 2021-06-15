using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Entity
{
   
        public class User : BaseEntity
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
}
