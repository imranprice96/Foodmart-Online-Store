using Foodmart.Models;
using System.Data.Entity;

namespace Foodmart.OSDB
{
    public class StoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductImageMapping> ProductImageMappings { get; set; }

        public System.Data.Entity.DbSet<Foodmart.ViewModels.EditUserViewModel> EditUserViewModels { get; set; }
    }
}