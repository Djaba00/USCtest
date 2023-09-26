using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtest.DAL.Entities;

namespace USCtest.DAL.DataContext.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("Users");

            builder.HasOne(u => u.ApplicationUser)
                .WithOne(au => au.UserProfile)
                .HasForeignKey<UserProfile>(u => u.Id);

            builder.Property(u => u.FirstName).IsRequired();

            builder.Property(u => u.LastName).IsRequired();

            builder.Property(u => u.PassportSeries).HasColumnType("nchar(4)");
            builder.Property(u => u.PassportNumber).HasColumnType("nchar(6)");
        }
    }
}
