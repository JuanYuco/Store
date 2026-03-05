using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Quantity).IsRequired();
            builder.Property(c => c.ProductId).IsRequired();
            builder.Property(c => c.OrderId).IsRequired();
            builder.Property(c => c.Quantity).IsRequired();

            builder.HasOne(c => c.Order)
                .WithMany(v => v.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Product)
                .WithMany(v => v.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
