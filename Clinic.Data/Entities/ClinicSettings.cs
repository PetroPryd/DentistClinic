using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clinic.Data.Entities
{
    // One row only (Id = 1). Everything that differs between clinics lives here.
    // Secrets (SMTP password, Google client secret) never go here: they stay in
    // user secrets / environment variables.
    public class ClinicSettings
    {
        public int Id { get; set; } = 1;

        [MaxLength(150)] public string Name { get; set; } = "";
        [MaxLength(500)] public string? LogoUrl { get; set; }
        [MaxLength(9)] public string PrimaryColor { get; set; } = "#0E7C86";
        [MaxLength(9)] public string AccentColor { get; set; } = "#F2A65A";

        [MaxLength(200)] public string Address { get; set; } = "";
        [MaxLength(100)] public string City { get; set; } = "";
        [MaxLength(20)] public string PostalCode { get; set; } = "";
        [MaxLength(2)] public string CountryCode { get; set; } = "HR";
        [MaxLength(50)] public string Phone { get; set; } = "";
        [MaxLength(200)] public string Email { get; set; } = "";
        [MaxLength(1000)] public string? MapEmbedUrl { get; set; }

        [MaxLength(50)] public string TimeZoneId { get; set; } = "Europe/Zagreb";
        [MaxLength(10)] public string DefaultLanguageCode { get; set; } = "hr";

        // Scheduling rules
        public int SlotMinutes { get; set; } = 15;
        public int BufferMinutes { get; set; } = 5;
        public int MaxBookingDaysAhead { get; set; } = 90;
        public int CancellationCutoffHours { get; set; } = 12;
        public int MaxGroupSize { get; set; } = 4;
        public int VerificationWindowMinutes { get; set; } = 60;

        // Notifications
        public int FirstReminderHours { get; set; } = 24;
        public int SecondReminderHours { get; set; } = 1;
        public bool SmsEnabled { get; set; }

        // Waitlist
        public int MaxActiveWaitlistEntries { get; set; } = 5;

        // Demo site: banner, demo logins, nightly reset, no real SMS
        public bool IsDemo { get; set; }
    }
}
