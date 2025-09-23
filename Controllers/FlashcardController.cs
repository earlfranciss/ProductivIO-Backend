using ProductivIOBackend.Models;
using ProductivIOBackend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProductivIOBackend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class FlashcardController : ControllerBase
    {
        private readonly AppDbContext _db;

        public FlashcardController(AppDbContext db) => _db = db;

        // GET : /api/Flashcard
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _db.Users
                .Where(u => u.Email.Contains(""))
                .ToListAsync();

            return Ok(users);
        }
    }

}