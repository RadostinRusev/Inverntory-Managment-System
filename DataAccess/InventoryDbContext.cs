using Inverntory_Managment_System.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.DataAccess
{
    public class InventoryDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
             public DbSet<Product> Products { get; set; }
        public DbSet<EditingHistory> EditingHistorys { get; set; }
        public InventoryDbContext()
        {
            Users = this.Set<User>();
            Products = this.Set<Product>();
            EditingHistorys = this.Set<EditingHistory>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-JD4P6UL\\SQLEXPRESS01;Database=InventoryDB;Trusted_Connection=True;");
        }
    }
}
