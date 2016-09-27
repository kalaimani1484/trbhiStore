using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TrbhiStore.Models.DB
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base("name=StoreEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreEntities, StoreDBMigrations.Configuration>("StoreEntities"));
            this.Database.CommandTimeout = 600;
        }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

    }
}