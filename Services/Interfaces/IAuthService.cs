using Microsoft.AspNetCore.Identity;
using ProductivIOBackend.Models;
using ProductivIOBackend.DTOs;

namespace ProductivIOBackend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User?> ValidateUserAsync(string email);
        PasswordVerificationResult VerifyPassword(User user, string password);
        Task<AuthResult> RegisterUserAsync(RegisterRequest request);
    }

}