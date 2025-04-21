using FeedBridge_00.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedBridge_00.Models.Config
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title).HasColumnType("varchar").HasMaxLength(50);

            builder.Property(x => x.Content).HasColumnType("nvarchar(max)");

            builder.Property(x => x.IsRead).HasDefaultValue(false);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(x => x.User).WithMany(x => x.Notifications).HasForeignKey(x => x.User_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Notifications");
        }
    }
}
