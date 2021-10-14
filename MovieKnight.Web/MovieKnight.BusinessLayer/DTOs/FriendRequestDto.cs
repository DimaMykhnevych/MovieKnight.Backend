using MovieKnight.DataLayer.Enums;
using MovieKnight.DataLayer.Models;
using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class FriendRequestDto
    {
        public Guid SenderId { get; set; }
        public AppUser Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public AppUser Receiver { get; set; }

        public FriendRequestStatus FriendRequestStatus { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
