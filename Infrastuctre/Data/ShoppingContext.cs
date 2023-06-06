using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastuctre.Data
{
    public class ShoppingContext: IdentityDbContext<TheUser>
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {
            
        }

        public ShoppingContext()
        {
            
        }


        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        
    }
}
