using Microsoft.AspNetCore.Identity;
using ProductivIOBackend.Models;

namespace ProductivIOBackend.Services.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(User user, string password);

        PasswordVerificationResult VerifyPassword(User user, string hashPassword, string inputPassword);
    }
}