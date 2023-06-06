using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastuctre.Data.Config
{
    public class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).HasColumnType("decimal").HasPrecision(18,2);
          
           
        }
    }
}
