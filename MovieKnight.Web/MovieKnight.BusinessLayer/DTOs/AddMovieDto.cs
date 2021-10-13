using System;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class AddMovieDto
    {
        public Guid Id { get; set; }
        public string IMDbId { get; set; }
    }
}
