using ProductivIOBackend.Models;

namespace ProductivIOBackend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> ValidateUserAsync(string email, string password);

    }

}