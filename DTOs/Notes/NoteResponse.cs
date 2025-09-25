using ProductivIOBackend.Models;

namespace ProductivIOBackend.DTOs
{
    public class NoteResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}