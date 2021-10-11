using Microsoft.AspNetCore.Identity;
using MovieKnight.DataLayer.Enums;
using System;
using System.Collections.Generic;

namespace MovieKnight.DataLayer.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            WatchHistory = new List<WatchHistory>();
            Friends = new List<Friends>();
            FriendRequests = new List<FriendRequest>();
        }

        public DateTime RegistryDate { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Role { get; set; }
        public StoryVisibility StoryVisibility { get; set; }
        public IEnumerable<WatchHistory> WatchHistory { get; set; }
        public IEnumerable<Friends> Friends { get; set; }
        public IEnumerable<FriendRequest> FriendRequests { get; set; }
    }
}
