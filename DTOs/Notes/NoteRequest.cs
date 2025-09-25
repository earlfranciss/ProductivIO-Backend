using ProductivIOBackend.Models;

namespace ProductivIOBackend.DTOs
{
    public class NoteRequest
    {
        public string Title { get; set; } = string.Empty;
        public string? Content { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}