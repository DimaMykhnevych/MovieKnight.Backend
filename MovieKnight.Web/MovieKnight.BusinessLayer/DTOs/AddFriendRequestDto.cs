using MovieKnight.DataLayer.Enums;
using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class AddFriendRequestDto
    {
        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public FriendRequestStatus FriendRequestStatus { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
