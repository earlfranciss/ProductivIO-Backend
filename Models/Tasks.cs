using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivIOBackend.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public required User User { get; set; }


        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Please set task priority.")]
        public string Priority { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please set task status.")]
        public string Status { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }

}