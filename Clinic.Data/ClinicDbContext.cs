using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Data
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) { }

        public DbSet<Language> Languages => Set<Language>();
        public DbSet<ClinicSettings> ClinicSettings => Set<ClinicSettings>();

        // Rules that apply to every property of a type, in every table
        protected override void ConfigureConventions(ModelConfigurationBuilder c)
        {
            c.Properties<DateTime>().HaveColumnType("timestamp without time zone");

            c.Properties<decimal>().HavePrecision(10, 2);
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            // Finds every IEntityTypeConfiguration<T> class in this project and applies it,
            // so new tables only need a new configuration class, not an edit here.
            b.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
        }
    }
}
