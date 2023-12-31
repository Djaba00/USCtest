﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using USCtest.DAL.DataContext.ModelConfigurations;
using USCtest.DAL.Entities;

namespace USCtest.DAL.DataContext
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Tax> Taxes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserProfileConfiguration());
            builder.ApplyConfiguration(new FlatConfiguration());
            builder.ApplyConfiguration(new TaxConfiguration());
        }
    }
}
