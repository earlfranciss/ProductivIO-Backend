using ProductivIOBackend.Models;
using ProductivIOBackend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProductivIOBackend.DTOs;
using ProductivIOBackend.Services.Interfaces;

namespace ProductivIOBackend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService) {
            _noteService = noteService;
        }

        // GET : /api/Notes?userId=1
        // [HttpGet]
        // public async Task<IActionResult> GetAll([FromQuery] int userId)
        // {

        //     return Ok(notes);
        // }

        // // GET: /api/Notes/{id}
        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetNote([FromQuery] int id)
        // {
        //     var note = await _db.Notes.FindAsync(id);
        //     if (note == null)
        //         return NotFound("Note not found");

        //     return Ok(note);
        // }

        // // POST: /api/Notes
        // [HttpPost]
        // public async Task<IActionResult> PostNote([FromQuery] NoteRequest noteRequest)
        // {
        //     var note = await _db.Notes.
        // }


    }
}