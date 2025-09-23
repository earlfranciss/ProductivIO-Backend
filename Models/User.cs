using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivIOBackend.Models 
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;




        public ICollection<Notes> Notes { get; set; } = new List<Notes>();

        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();

        public ICollection<Pomodoro> Pomodoros { get; set; } = new List<Pomodoro>();

        public ICollection<Flashcards> Flashcards { get; set; } = new List<Flashcards>();

        public ICollection<Quizzes> Quizzes { get; set; } = new List<Quizzes>();
    }
}