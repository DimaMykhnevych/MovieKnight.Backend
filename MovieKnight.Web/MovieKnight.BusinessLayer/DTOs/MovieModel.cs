using System.Collections.Generic;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class MovieModel
    {
        public string Id { get; set; }
        public string Title { set; get; }
        public string Year { set; get; }
        public string ReleaseDate { set; get; }
        public string RuntimeStr { set; get; }
        public string Plot { set; get; } 
        public string Awards { set; get; }
        public string Image { get; set; }
        public string Type { set; get; }
        public string Directors { set; get; }
        public string Stars { set; get; }
        public List<StarShort> StarList { get; set; }
        public List<ActorShort> ActorList { get; set; }
        public string Genres { set; get; }
        public string Companies { get; set; }
        public string ContentRating { get; set; }
        public string IMDbRating { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class StarShort
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ActorShort
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string AsCharacter { get; set; }
    }
}
