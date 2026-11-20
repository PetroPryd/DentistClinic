using Clinic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Data.Configuration
{
    public class ClinicSettingsConfiguration : IEntityTypeConfiguration<ClinicSettings>
    {
        public void Configure(EntityTypeBuilder<ClinicSettings> e)
        {
            // We always set Id = 1 ourselves; the database must not generate it
            e.Property(x => x.Id).ValueGeneratedNever();

            e.ToTable(t =>
            {
                // Only one settings row can ever exist
                t.HasCheckConstraint("ck_clinic_settings_single_row", "id = 1");

                // Sensible values only
                t.HasCheckConstraint("ck_clinic_settings_values",
                    "slot_minutes > 0 AND buffer_minutes >= 0 AND max_group_size >= 1 " +
                    "AND first_reminder_hours > second_reminder_hours AND second_reminder_hours > 0");
            });
        }
    }
}
