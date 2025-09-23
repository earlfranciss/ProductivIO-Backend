using ProductivIOBackend.Models;

namespace ProductivIOBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(string email);
    }
}