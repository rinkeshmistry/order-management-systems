using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderManagementApi.Entities.Modules.Customer;
using OrderManagementApi.Entities.Modules.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementApi.Entities
{
    public class OrderManagementContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public OrderManagementContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("OrderManagementDatabase"));
        }

        #region Entities Declaration
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Identity Declaration
            modelBuilder.Entity<Customer>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CustomerContact>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderProduct>().Property(p => p.Id).ValueGeneratedOnAdd();
            #endregion

            #region Foreign Key Configuration
            modelBuilder.Entity<Customer>().HasMany(cc => cc.CustomerContacts).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId);
            modelBuilder.Entity<Customer>().HasMany(op => op.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<Order>().HasMany(op => op.OrderProducts).WithOne(o => o.Order).HasForeignKey(o => o.OrderId);
            #endregion
        }
    }
}
