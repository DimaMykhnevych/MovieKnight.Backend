using System;

namespace MovieKnight.DataLayer.Models
{
    public class Friends
    {
        public Guid Friend1Id { get; set; }
        public AppUser Friend1 { get; set; }


        public Guid Friend2Id { get; set; }
        public AppUser Friend2 { get; set; }
    }
}
