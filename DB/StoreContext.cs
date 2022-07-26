﻿using QuanLyBanHang.DB.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace QuanLyBanHang.DB
{
    public class StoreContext : System.Data.Entity.DbContext
    {
        public StoreContext() : base("StoreContext")
        {
            var initializer = new DropCreateDatabaseAlways<StoreContext>();
            Database.SetInitializer(initializer);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DeliveryEmployee> DeliveryEmployees { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<QuanLyBanHang.DB.Entities.Customer> Customers { get; set; }
    }
}