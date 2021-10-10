using Microsoft.AspNetCore.Identity;
using MovieKnight.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieKnight.DataLayer.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            Friends1 = new List<Friends>();
            Friends2 = new List<Friends>();

            FriendsRequestsSent = new List<FriendRequest>();
            FriendsRequestsReceived = new List<FriendRequest>();
        }

        public DateTime RegistryDate { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Role { get; set; }
        public StoryVisibility StoryVisibility { get; set; }
        public IEnumerable<WatchHistory> WatchHistory { get; set; }
        //public ICollection<FriendRequest> FriendRequests { get; set; }

        public ICollection<Friends> Friends1 { get; set; }
        public ICollection<Friends> Friends2 { get; set; }

        public ICollection<FriendRequest> FriendsRequestsSent { get; set; }
        public ICollection<FriendRequest> FriendsRequestsReceived { get; set; }
    }
}
