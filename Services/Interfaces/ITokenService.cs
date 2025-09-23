using ProductivIOBackend.Models;

namespace ProductivIOBackend.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
