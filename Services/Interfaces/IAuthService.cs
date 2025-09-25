using Microsoft.AspNetCore.Identity;
using ProductivIOBackend.Models;
using ProductivIOBackend.DTOs;

namespace ProductivIOBackend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(LoginRequest loginRequest);
        Task<AuthResult> RegisterUserAsync(RegisterRequest request);
    }

}