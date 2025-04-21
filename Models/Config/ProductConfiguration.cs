using FeedBridge_00.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedBridge_00.Models.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(n => n.Name).IsRequired().HasMaxLength(255).HasColumnType("varchar");

            builder.Property(i => i.Image).IsRequired().HasMaxLength(255);

            builder.Property(q => q.Quantity).IsRequired();

            builder.Property(c => c.Category).HasMaxLength(55).IsRequired().HasConversion<string>();

            builder.Property(c => c.Status).HasMaxLength(55).IsRequired().HasConversion<string>();

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(x => x.Admin).WithMany(x => x.Products).HasForeignKey(x => x.Admin_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.InventoryEmployee).WithMany(x => x.Products).HasForeignKey(x => x.InventoryEmployee_id)
                .OnDelete(DeleteBehavior.NoAction);

            // When many to many relation ==> create new table Explicitly
            builder.HasMany(x => x.Carts).WithMany(x => x.Products).UsingEntity(j => j.ToTable("CartProducts"));

            builder.ToTable("Products");
        }
    }
}
