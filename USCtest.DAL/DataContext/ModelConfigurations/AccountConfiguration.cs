using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USCtest.DAL.Entities;

namespace USCtest.DAL.DataContext.ModelConfigurations
{
    public class AccountConfiguration
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Accounts");

            builder.HasOne(u => u.UserProfile)
                .WithOne(au => au.ApplicationUser)
                .HasForeignKey<ApplicationUser>(u => u.UserProfileId);
        }
    }
}
