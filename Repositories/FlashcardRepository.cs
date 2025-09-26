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
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly AppDbContext _db;

        public FlashcardRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Flashcards>> GetAllFlashcardsAsync(int userId)
        {
            return await _db.Flashcards
                .Where(n => n.UserID == userId)
                .ToListAsync();
        }

        public async Task<Flashcards?> GetFlashcardAsync(int Id, int userId)
        {
            return await _db.Flashcards
                .Where(n => n.Id == Id && n.UserID == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<Flashcards?> AddFlashcardAsync(Flashcards flashcard)
        {
            _db.Flashcards.Add(flashcard);
            await _db.SaveChangesAsync();
            return flashcard;
        }

        public async Task<Flashcards?> UpdateFlashcardAsync(Flashcards flashcard)
        {
            _db.Flashcards.Update(flashcard);
            await _db.SaveChangesAsync();
            return flashcard;
        }

        public async Task<bool> DeleteFlashcardAsync(int Id, int userId)
        {
            var flashcard = await _db.Flashcards
                .FirstOrDefaultAsync(n => n.Id == Id && n.UserID == userId);
            if (flashcard == null) return false;

            _db.Flashcards.Remove(flashcard);
            await _db.SaveChangesAsync();
            return true;
        }
        
    }
}   