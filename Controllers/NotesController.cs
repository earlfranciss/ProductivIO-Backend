using ProductivIOBackend.Models;
using ProductivIOBackend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProductivIOBackend.DTOs;

namespace ProductivIOBackend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class NotesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public NotesController(AppDbContext db) => _db = db;

        // GET : /api/Notes?userId=1
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int userId)
        {
            var notes = await _db.Notes
                .Where(n => n.UserID == userId)
                .ToListAsync();

            return Ok(notes);
        }

        // GET: /api/Notes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNote([FromQuery] int id)
        {
            var note = await _db.Notes.FindAsync(id);
            if (note == null)
                return NotFound("Note not found");

            return Ok(note);
        }

        // POST: /api/Notes
        [HttpPost]
        public async Task<IActionResult> PostNote([FromQuery] NoteRequest noteRequest)
        {
            var note = await 
        }


    }
}