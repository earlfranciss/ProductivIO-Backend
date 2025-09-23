using ProductivIOBackend.Models;
using ProductivIOBackend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProductivIOBackend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TasksController(AppDbContext db) => _db = db;

        // GET : /api/Tasks
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