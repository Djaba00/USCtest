using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using USCtest.DAL.DataContext.ModelConfigurations;
using USCtest.DAL.Entities;

namespace USCtest.DAL.DataContext
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Tax> Taxes { get; set; }

        public ApplicationContext() { }

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
