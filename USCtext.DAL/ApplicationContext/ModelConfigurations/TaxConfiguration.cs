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
    public class TaxConfiguration : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.ToTable("Taxes").HasKey(t => t.Id);

            builder.Property(t => t.IsPayed).HasDefaultValue(false);
        }
    }
}
