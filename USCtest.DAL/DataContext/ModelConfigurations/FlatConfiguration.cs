using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using USCtest.DAL.Entities;

namespace USCtest.DAL.DataContext.ModelConfigurations
{
    public class FlatConfiguration : IEntityTypeConfiguration<Flat>
    {
        public void Configure(EntityTypeBuilder<Flat> builder)
        {
            builder.ToTable("Flats").HasKey(f => f.Id);

            builder.Property(f => f.Street).IsRequired();

            builder.Property(f => f.IsColdWaterDevice).HasDefaultValue(false);
            builder.Property(f => f.IsHotWaterDevice).HasDefaultValue(false);
            builder.Property(f => f.IsElectricPowerDevice).HasDefaultValue(false);

            builder.HasMany(f => f.Users)
                .WithMany(u => u.Flats)
                .UsingEntity<Registration>(
                    j => j
                    .HasOne(r => r.User)
                    .WithMany(u => u.Registrations)
                    .HasForeignKey(r => r.UserId),
                    j => j
                    .HasOne(r => r.Flat)
                    .WithMany(f => f.Registrations)
                    .HasForeignKey(r => r.FlatId),
                    j =>
                    {;
                        j.HasKey(t => new { t.UserId, t.FlatId });
                        j.ToTable("Registrations");
                        j.Property(r => r.RegistrationDate).HasColumnType("datetime2");
                        j.Property(r => r.RemoveDate).HasColumnType("datetime2").HasDefaultValue(null);
                    });
        }
    }
}
