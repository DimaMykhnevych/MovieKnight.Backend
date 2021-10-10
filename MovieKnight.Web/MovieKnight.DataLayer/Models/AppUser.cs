using Microsoft.AspNetCore.Identity;
using MovieKnight.DataLayer.Enums;
using System;

namespace MovieKnight.DataLayer.Models
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime RegistryDate { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Role { get; set; }
        public StoryVisibility StoryVisibility { get; set; }
    }
}
