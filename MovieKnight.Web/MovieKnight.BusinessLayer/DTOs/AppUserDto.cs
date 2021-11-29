using MovieKnight.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class AppUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime RegistryDate { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Email { get; set; }
        public StoryVisibility StoryVisibility { get; set; }
        public IEnumerable<WatchHistoryDto> WatchHistory { get; set; }
        public IEnumerable<FriendsDto> Friends { get; set; }
        public IEnumerable<FriendRequestDto> FriendRequests { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
    }

}
