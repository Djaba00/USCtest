﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using USCtext.DAL.DataContext.ModelConfigurations;
using USCtext.DAL.Entities;

namespace USCtext.DAL.DataContext
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Tax> Taxes { get; set; }

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