using FeedBridge_00.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FeedBridge_00.Models.Config
{
    public class UserPhoneConfiguration : IEntityTypeConfiguration<UserPhone>
    {
        public void Configure(EntityTypeBuilder<UserPhone> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.PhoneNumber).IsRequired().HasColumnType("varchar").HasMaxLength(15);

            builder.HasOne(u => u.User).WithMany(x => x.PhoneNumbers).HasForeignKey(x => x.User_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("UserPhones");
        }
    }
}
