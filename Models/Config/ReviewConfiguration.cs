using FeedBridge_00.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedBridge_00.Models.Config
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(t => t.Text).HasColumnType("varchar").HasMaxLength(255);

            builder.Property(r => r.Rating).HasMaxLength(5).HasColumnType("INT");

            builder.Property(c => c.Status).HasMaxLength(55).IsRequired().HasConversion<string>();

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate();

            builder.HasOne(x => x.User).WithMany(x => x.Reviews).HasForeignKey(x => x.User_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Admin).WithMany(x => x.Reviews).HasForeignKey(x => x.Admin_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Reviews");
        }
    }
}
