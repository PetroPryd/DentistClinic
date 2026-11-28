using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clinic.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        [MaxLength(100)] public string FirstName { get; set; } = "";
        [MaxLength(100)] public string LastName { get; set; } = "";
        [MaxLength(10)] public string PreferredLanguageCode { get; set; } = "hr";
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}
