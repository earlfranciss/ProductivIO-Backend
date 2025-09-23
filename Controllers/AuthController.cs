using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ProductivIOBackend.Data;
using ProductivIOBackend.Models;
using ProductivIOBackend.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ProductivIOBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        // POST: api/Auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
                return BadRequest("Username and password are required");

            // find active user by username
            var user = await _authService.ValidateUserAsync(loginRequest.Email, loginRequest.Password);

            if (user == null)
                return Unauthorized("Email does not exist.");

            // verify password hash
            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Incorrect password.");

            // generate JWT
            var token = _tokenService.GenerateToken(user);

            // hide password before sending back
            var userDto = new 
            {
                user.Id,
                user.Name,
                user.Email,
                user.CreatedAt,
            };

            return Ok(new { token, user = userDto });
        }

    }
}
