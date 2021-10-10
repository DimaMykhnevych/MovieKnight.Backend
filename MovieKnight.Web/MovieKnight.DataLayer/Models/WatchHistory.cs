using System;
using System.Collections.Generic;
using System.Text;

namespace MovieKnight.DataLayer.Models
{
    class WatchHistory
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
    }
}
