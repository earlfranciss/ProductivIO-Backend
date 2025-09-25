using ProductivIOBackend.Models;

namespace ProductivIOBackend.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public UserResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            CreatedAt = user.CreatedAt;
        }
    }
}