using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USCtest.DAL.Entities;

namespace USCtest.DAL.DataContext.ModelConfigurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);

            builder.HasOne(u => u.ApplicationUser)
                .WithOne(au => au.UserProfile)
                .HasForeignKey<UserProfile>(u => u.ApplicationUserId); 

            builder.Property(u => u.FirstName).IsRequired();

            builder.Property(u => u.LastName).IsRequired();

            builder.Property(u => u.PassportSeries).HasColumnType("nchar(4)");
            builder.Property(u => u.PassportNumber).HasColumnType("nchar(6)");
        }
    }
}
