using Inverntory_Managment_System.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.DataAccess
{
    public class UserRepository:BaseRepository<User>
    {
        public UserRepository()
        { }

        public UserRepository(UnitOfWork uow)
            : base(uow)
        { }
    }
}
