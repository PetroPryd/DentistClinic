using Clinic.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Data
{
    // IdentityDbContext<user type, role type, key type>
    public class ClinicDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) { }

        // Users, Roles, UserRoles... come from IdentityDbContext. Don't add your own.
        public DbSet<Language> Languages => Set<Language>();
        public DbSet<ClinicSettings> ClinicSettings => Set<ClinicSettings>();

        protected override void ConfigureConventions(ModelConfigurationBuilder c)
        {
            c.Properties<DateTime>().HaveColumnType("timestamp without time zone");
            c.Properties<decimal>().HavePrecision(10, 2);
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            // MUST be first: configures the 7 Identity tables (keys, indexes, relationships).
            // Without it you get errors like "The entity type 'IdentityUserLogin<int>' requires a primary key".
            base.OnModelCreating(b);

            // Identity's default names are AspNetUsers, AspNetRoles... Shorter names:
            b.Entity<ApplicationUser>().ToTable("users");
            b.Entity<IdentityRole<int>>().ToTable("roles");
            b.Entity<IdentityUserRole<int>>().ToTable("user_roles");
            b.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
            b.Entity<IdentityUserLogin<int>>().ToTable("user_logins");
            b.Entity<IdentityUserToken<int>>().ToTable("user_tokens");
            b.Entity<IdentityRoleClaim<int>>().ToTable("role_claims");

            b.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
        }
    }
}
