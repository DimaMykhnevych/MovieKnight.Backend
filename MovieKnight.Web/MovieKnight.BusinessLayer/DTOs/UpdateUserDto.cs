using MovieKnight.DataLayer.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieKnight.BusinessLayer.DTOs
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public DateTime BirthdayDate { get; set; }
        public StoryVisibility StoryVisibility { get; set; }

        [Required]
        public string Username { get; set; }
        [MinLength(6)]
        public string Password { get; set; }
        [MinLength(6)]
        public string NewPassword { get; set; }
        [MinLength(6)]
        public string ConfirmPassword { get; set; }
    }
}
