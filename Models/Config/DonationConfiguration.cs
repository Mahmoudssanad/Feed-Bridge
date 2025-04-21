using FeedBridge_00.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedBridge_00.Models.Config
{
    public class DonationConfiguration : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Quantity).IsRequired();

            builder.Property(x => x.Status).IsRequired().HasConversion<string>();
            builder.Property(x => x.Type).IsRequired().HasConversion<string>();

            builder.Property(u => u.Expiration)
              .HasColumnType("DATETIME2")
              .IsRequired();

            builder.Property(x => x.Image).HasMaxLength(500).IsRequired(false);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt)
               .HasDefaultValueSql("GETUTCDATE()") 
               .ValueGeneratedOnAddOrUpdate(); 

            builder.HasOne(x => x.Admin).WithMany(x => x.Donations)
                .HasForeignKey(x => x.Admin_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User).WithMany(x => x.Donations)
                .HasForeignKey(x => x.User_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Delivery).WithMany(x => x.Donations)
                .HasForeignKey(x => x.Delivery_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Donations");
        }
    }
}
