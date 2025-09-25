using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductivIOBackend.Data;
using ProductivIOBackend.DTOs;
using ProductivIOBackend.Models;
using ProductivIOBackend.Repositories.Interfaces;
using ProductivIOBackend.Services;

namespace ProductivIOBackend.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _db;

        public NoteRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Notes>> GetAllNotesAsync(int userId)
        {
            return await _db.Notes
                .Where(n => n.UserID == userId)
                .ToListAsync();
        }

        public async Task<Notes?> GetNoteAsync(int Id, int userId)
        {
            return await _db.Notes
                .Where(n => n.Id == Id && n.UserID == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<Notes?> AddNoteAsync(Notes note)
        {
            _db.Notes.Add(note);
            await _db.SaveChangesAsync();
            return note;
        }
        
        public async Task<Notes?> UpdateNoteAsync(Notes note)
        {
            _db.Notes.Update(note);
            await _db.SaveChangesAsync();
            return note;
        }
    }
}   