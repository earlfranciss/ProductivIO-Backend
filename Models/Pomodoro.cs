using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivIOBackend.Models
{
    public class Pomodoro
    {
        [Key]
        public int Id { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [Required(ErrorMessage = "Please set time duration.")]
        public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(0);

        [Required(ErrorMessage = "Please set session type.")]
        public string SessionType { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}