using MovieKnight.DataLayer.Enums;
using System;

namespace MovieKnight.DataLayer.Models
{
    public class FriendRequest
    {
        public Guid SenderId { get; set; }
        public AppUser Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public AppUser Receiver { get; set; }

        public FriendRequestStatus FriendRequestStatus {get; set;}
        public DateTime RequestDate { get; set; }

    }
}
