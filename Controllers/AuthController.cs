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
            var result = await _authService.LoginAsync(loginRequest);
            if (!result.Success)
                return Unauthorized(result.Message);

            return Ok(new { token = result.Token, user = result.User });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var result = await _authService.RegisterUserAsync(registerRequest);
            if (!result.Success || result.User == null)
                return BadRequest(result.Message);

            return Ok(new { message = result.Message, user = result.User });
        }
    }
}
