using System;

namespace MovieKnight.DataLayer.Models.Auth
{
    public class UserAuthInfo
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime RegistryDate { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Email { get; set; }
    }
}
