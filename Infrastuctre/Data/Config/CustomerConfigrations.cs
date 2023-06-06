using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastuctre.Data.Config
{
    public class CustomerConfigrations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.FullName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Mobile).IsRequired().HasMaxLength(11) ;
            builder.Property(c => c.Address).HasMaxLength(250);
            
        }
    }
}
