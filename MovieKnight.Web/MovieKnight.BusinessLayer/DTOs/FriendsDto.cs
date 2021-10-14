using MovieKnight.DataLayer.Models;
using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class FriendsDto
    {
        public Guid Friend1Id { get; set; }
        public AppUser Friend1 { get; set; }


        public Guid Friend2Id { get; set; }
        public AppUser Friend2 { get; set; }
    }
}
