using Foodmart.Models;
using System.Data.Entity;

namespace Foodmart.OSDB
{
    public class StoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}