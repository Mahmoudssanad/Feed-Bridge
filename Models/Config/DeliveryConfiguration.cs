using FeedBridge_00.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedBridge_00.Models.Config
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FirstName).IsRequired().HasColumnType("varchar").HasMaxLength(17);
            builder.Property(x => x.LastName).IsRequired().HasColumnType("varchar").HasMaxLength(17);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Password).IsRequired();

            builder.Property(x => x.Status).HasConversion<string>().IsRequired();

            builder.HasOne(x => x.InventoryEmployee).WithMany(x => x.Deliveries)
                .HasForeignKey(x => x.InventoeyEmployee_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt)
               .HasDefaultValueSql("GETUTCDATE()") // تحديث افتراضي عند الإنشاء
               .ValueGeneratedOnAddOrUpdate(); // يتم تحديثه عند التعديل

            builder.ToTable("Deliveries");
        }
    }
}
