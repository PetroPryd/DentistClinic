using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clinic.Data.Entities
{
    public class Language
    {
        [MaxLength(10)] public string Code { get; set; } = "";        // "hr", "en", "uk"
        [MaxLength(50)] public string Name { get; set; } = "";        // "Ukrainian"
        [MaxLength(50)] public string NativeName { get; set; } = "";  // "Українська"
        public bool IsEnabled { get; set; } = true;
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
    }
}
