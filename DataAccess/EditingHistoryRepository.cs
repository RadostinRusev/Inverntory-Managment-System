using Inverntory_Managment_System.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.DataAccess
{
    public class EditingHistoryRepository : BaseRepository<EditingHistory>
    {

        public EditingHistoryRepository()
        { }

        public EditingHistoryRepository(UnitOfWork uow)
            : base(uow)
        { }
    }
}
