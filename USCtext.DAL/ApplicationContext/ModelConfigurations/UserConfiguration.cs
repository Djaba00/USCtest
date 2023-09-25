using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtext.DAL.Entities;

namespace USCtext.DAL.DataContext.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.FirstName).IsRequired();

            builder.Property(u => u.LastName).IsRequired();

            builder.Property(u => u.PassportSeries).HasColumnType("nchar(4)");
            builder.Property(u => u.PassportNumber).HasColumnType("nchar(6)");
        }
    }
}
