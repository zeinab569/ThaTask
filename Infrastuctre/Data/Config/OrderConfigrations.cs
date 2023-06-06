using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastuctre.Data.Config
{
    public class OrderConfigrations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Id).IsRequired();
            builder.HasOne(o => o.Customers).WithMany()
                .HasForeignKey(a => a.CustomerId).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasOne(o => o.Products).WithMany()
                .HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
