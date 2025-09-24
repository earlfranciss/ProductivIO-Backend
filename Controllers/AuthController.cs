using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProductivIOBackend.Data;
using ProductivIOBackend.Models;
using ProductivIOBackend.Services.Interfaces;
using ProductivIOBackend.DTOs;
using ProductivIOBackend.Repositories.Interfaces;

using Microsoft.AspNetCore.Identity;

namespace ProductivIOBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;


        public AuthController(IAuthService authService, ITokenService tokenService, IUserRepository userRepository)
        {
            _authService = authService;
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
                return BadRequest("Email and password are required");

            // Find user
            var user = await _authService.ValidateUserAsync(loginRequest.Email);
            if (user == null)
                return Unauthorized("Email does not exist.");

            // Verify password
            var result = _authService.VerifyPassword(user, loginRequest.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Incorrect password.");

            // Rehash password to make password stronger over time
            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                await _userRepository.UpdateUserAsync(user);
            }

            // Generate JWT
            var token = _tokenService.GenerateToken(user);

            // Hide password before sending back
            var userDto = new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
            };

            return Ok(new { token, user = userDto });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            // Checks for missing inputs
            if (string.IsNullOrEmpty(registerRequest.Name) || string.IsNullOrEmpty(registerRequest.Email) || string.IsNullOrEmpty(registerRequest.Password))
                return BadRequest("Email and password are required");

            // Register user
            var result = await _authService.RegisterUserAsync(registerRequest);

            if (!result.Success || result.User == null)
                return BadRequest(result.Message);

            // Hide password before sending back
            var userDto = new UserResponse
            {
                Id = result.User.Id,
                Name = result.User.Name,
                Email = result.User.Email,
                CreatedAt = result.User.CreatedAt,
            };

            return Ok(new { message = "User registered successfully.", user = userDto });
        }
    }
}
