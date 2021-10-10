using System.ComponentModel.DataAnnotations;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class CreateUserDto
    {
        public string Role { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
