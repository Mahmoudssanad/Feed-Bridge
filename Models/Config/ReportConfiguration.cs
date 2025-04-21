using FeedBridge_00.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedBridge_00.Models.Config
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Title).IsRequired().HasColumnType("VarChar").HasMaxLength(50);
            builder.Property(x => x.Content).IsRequired().HasColumnType("VarChar").HasMaxLength(255);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(x => x.User).WithMany(x => x.Reports).HasForeignKey(x => x.User_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Admin).WithMany(x => x.Reports).HasForeignKey(x => x.Admin_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Notification).WithOne(x => x.Report).HasForeignKey<Notification>(x => x.Report_id)
            .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Reports");
        }
    }
}
