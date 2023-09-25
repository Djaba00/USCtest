using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using USCtext.DAL.ApplicationContext.ModelConfigurations;
using USCtext.DAL.Entities;

namespace USCtext.DAL.ApplicationContext
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        DbSet<Flat> Flats { get; set; }
        DbSet<Tax> Taxes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new FlatConfiguration());
            builder.ApplyConfiguration(new TaxConfiguration());
        }
    }
}
