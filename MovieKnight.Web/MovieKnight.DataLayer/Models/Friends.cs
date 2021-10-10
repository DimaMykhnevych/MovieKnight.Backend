using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MovieKnight.DataLayer.Models
{
    public class Friends
    {
        public Guid Id { get; set; }

        public Guid AppUser1Id { get; set; }
        public AppUser AppUser1 { get; set; }


        public Guid AppUser2Id { get; set; }
        public AppUser AppUser2 { get; set; }
    }
}
