using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Entity
{
    public class ProductRepository:BaseRepository<Product>
    {
        public ProductRepository()
        { }

        public ProductRepository(UnitOfWork uow)
            : base(uow)
        { }
    }
}
