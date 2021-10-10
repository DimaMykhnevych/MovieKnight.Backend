using Microsoft.AspNetCore.Identity;
using System;

namespace MovieKnight.DataLayer.Models
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime RegistryDate { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Role { get; set; }

    }
}
