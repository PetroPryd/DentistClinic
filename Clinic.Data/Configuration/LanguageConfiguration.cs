using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Data.Configuration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> e)
        {
            e.HasKey(x => x.Code);

            e.HasIndex(x => x.IsDefault)
                .IsUnique()
                .HasFilter("is_default");
        }
    }
}
