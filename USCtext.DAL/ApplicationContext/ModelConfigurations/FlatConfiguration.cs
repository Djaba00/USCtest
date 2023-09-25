using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USCtext.DAL.Entities;

namespace USCtext.DAL.ApplicationContext.ModelConfigurations
{
    public class FlatConfiguration : IEntityTypeConfiguration<Flat>
    {
        public void Configure(EntityTypeBuilder<Flat> builder)
        {
            builder.ToTable("Flats").HasKey(f => f.Id);

            builder.Property(f => f.Street).IsRequired();

            builder.Property(f => f.IsColdWatherDevice).HasDefaultValue(false);
            builder.Property(f => f.IsHotWatherDevice).HasDefaultValue(false);
            builder.Property(f => f.IsElectricPowerDevice).HasDefaultValue(false);
        }
    }
}
