namespace Foodmart.Migrations.StoreConfiguration
{
    using Models;
    using System.Collections.Generic;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class StoreConfiguration : DbMigrationsConfiguration<Foodmart.OSDB.StoreContext>
    {
        public StoreConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Foodmart.OSDB.StoreContext";
        }
        protected override void Seed(Foodmart.OSDB.StoreContext context)
        {
            var departments = new List<Department>
            {
                new Department {Name = "Produce" },
                new Department {Name = "Grocery" },
                new Department {Name = "Seafood" },
                new Department {Name = "Butchery" },
                new Department {Name = "Chilled Foods" },
                new Department {Name = "Bakery" },
                new Department {Name = "Liquor" }
             };
            departments.ForEach(d => context.Departments.AddOrUpdate(p => p.Name, d));
            context.SaveChanges();
            var products = new List<Product>
            {
                new Product {Name = "Apple", Description = "Gala apples", Price = 0.2m, DepartmentID= departments.Single(d=>d.Name == "Produce").ID},
                new Product {Name = "Carrot", Description = "Carrots loose", Price = 0.1m, DepartmentID= departments.Single(d=>d.Name == "Produce").ID},
                new Product {Name = "Baked Beans", Description = "400g net", Price = 1.1m , DepartmentID= departments.Single(d=>d.Name == "Grocery").ID},
                new Product {Name = "Plain flour 1kg", Description = "1kg of plain flour", Price = 1.99m, DepartmentID= departments.Single(d=>d.Name == "Grocery").ID},
                new Product {Name = "Ready Salted Chips", Description = "Plain ready salted flavour", Price = 1.09m, DepartmentID= departments.Single(d=>d.Name == "Grocery").ID},
                new Product {Name = "King Prawns 500g", Description = "Pre-cooked king prawns", Price = 10.99m, DepartmentID= departments.Single(d=>d.Name == "Seafood").ID},
                new Product {Name = "Salmon Fillet", Description = "500g of fillet salmon", Price = 8, DepartmentID= departments.Single(d=>d.Name == "Seafood").ID},
                new Product {Name = "Premium Mince 1kg", Description = "NZ premium beef mince", Price = 13.99m, DepartmentID= departments.Single(d=>d.Name == "Butchery").ID},
                new Product {Name = "Beef Sausages 6pk", Description = "Six beef sausages", Price = 6.99m, DepartmentID= departments.Single(d=>d.Name == "Butchery").ID},
                new Product {Name = "Blue Milk 2L", Description = "Standard milk", Price = 2.09m, DepartmentID= departments.Single(d=>d.Name == "Chilled Foods").ID},
                new Product {Name = "Butter 500g", Description = "Salted butter 500g", Price = 6.99m, DepartmentID= departments.Single(d=>d.Name == "Chilled Foods").ID},
                new Product {Name = "Chocolate Cupcakes 6pk", Description = "Six pack of chocolate cupcakes", Price = 4.50m, DepartmentID= departments.Single(d=>d.Name == "Bakery").ID},
                new Product {Name = "Bread Rolls 6pk", Description = "Six bread rolls", Price = 3, DepartmentID= departments.Single(d=>d.Name == "Bakery").ID},
                new Product {Name = "Corona 12pk", Description = "355ml bottles", Price = 12.99m, DepartmentID= departments.Single(d=>d.Name == "Liquor").ID},
                new Product {Name = "Clearwater Cove", Description = "White wine 750ml", Price = 21.99m, DepartmentID= departments.Single(d=>d.Name == "Liquor").ID},
            };
            products.ForEach(d => context.Products.AddOrUpdate(p => p.Name, d));
            context.SaveChanges();
            var orders = new List<Order>
            {
                 new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street", Town="Town1",
                 Country="Country", PostCode="PostCode" }, TotalPrice=2.09m,
                 UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 1) ,
                 DeliveryName="Admin" },
                 new Order { DeliveryAddress = new Address { AddressLine1="1 Some Street", Town="Town1",
                 Country="Country", PostCode="PostCode" }, TotalPrice=12.99m,
                 UserID="admin@example.com", DateCreated=new DateTime(2014, 1, 1) ,
                 DeliveryName="Admin" }
            };
            orders.ForEach(c => context.Orders.AddOrUpdate(o => o.DateCreated, c));
            context.SaveChanges();
            var orderLines = new List<OrderLine>
            {
                /*new OrderLine { OrderID = 1, ProductID = products.Single( c=> c.Name == "L").ID,
                    ProductName ="", Quantity =1, UnitPrice=products.Single( c=> c.Name == "L").Price }*/
                 new OrderLine { OrderID = 1, ProductID = products.Single( c=> c.Name == "Blue Milk 2L").ID,
                    ProductName ="Blue Milk 2L", Quantity =1, UnitPrice=products.Single( c=> c.Name == "Blue Milk 2L").Price },
                 new OrderLine { OrderID = 1, ProductID = products.Single( c=> c.Name == "Corona 12pk").ID,
                    ProductName ="Corona 12pk", Quantity =1, UnitPrice=products.Single( c=> c.Name == "Corona 12pk").Price }
            };
            orderLines.ForEach(c => context.OrderLines.AddOrUpdate(ol => ol.OrderID, c));
            context.SaveChanges();
        }
    }
}
