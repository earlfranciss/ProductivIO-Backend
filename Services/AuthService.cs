using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductivIOBackend.Data;
using ProductivIOBackend.Models;
using ProductivIOBackend.DTOs;
using ProductivIOBackend.Repositories.Interfaces;
using ProductivIOBackend.Services.Interfaces;

namespace ProductivIOBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<User?> ValidateUserAsync(string email)
        {
            return await _userRepository.GetUserAsync(email);
        }

        public PasswordVerificationResult VerifyPassword(User user, string password)
        {
            return _passwordHasher.VerifyHashedPassword(user, user.Password, password);
        }

        public async Task<AuthResult> RegisterUserAsync(RegisterRequest request)
        {
            // Check if email already exists
            var existingUser = await _userRepository.GetUserAsync(request.Email);
            if (existingUser != null)
                return new AuthResult { Success = false, Message = "Email already registered."};

            // Create new user and hash password
            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                CreatedAt = DateTime.Now
            };

            newUser.Password = _passwordHasher.HashPassword(newUser, request.Password);

            // Save to database
            var savedUser = await _userRepository.AddUserAsync(newUser);
            return new AuthResult { Success= true, Message = "User created successfully.", User = savedUser };
        }
    }
}
