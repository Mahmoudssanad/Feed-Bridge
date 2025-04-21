using FeedBridge_00.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedBridge_00.Models.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(q => q.Quantity).IsRequired();

            builder.Property(c => c.Status).HasMaxLength(55).IsRequired().HasConversion<string>();

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(x => x.Admin).WithMany(x => x.Orders).HasForeignKey(x => x.Admin_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.User_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Delivery).WithMany(x => x.Orders).HasForeignKey(x => x.Delivery_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Cart).WithMany(x => x.Orders).HasForeignKey(x => x.Cart_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Orders");
        }
    }
}
