using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace TrbhiStore.Models.DB.StoreDBMigrations
{
    public class Configuration : DbMigrationsConfiguration<StoreEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TrbhiStore.Models.DB.StoreEntities context)
        {
            context.Products.AddOrUpdate( p => p.ProductId,
                new Products {ProductId = 1, ProductName = "Product 1", Price = 10, availableQuantity = 5, ImageURL = null},
                new Products { ProductId = 2, ProductName = "Product 2", Price = 20, availableQuantity = 5, ImageURL = null },
                new Products { ProductId = 3, ProductName = "Product 3", Price = 30, availableQuantity = 5, ImageURL = null },
                new Products { ProductId = 4, ProductName = "Product 4", Price = 40, availableQuantity = 5, ImageURL = null }
            );
        }
    }
}