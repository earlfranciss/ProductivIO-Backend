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
    public class QuizRepository : IQuizRepository
    {
        private readonly AppDbContext _db;

        public QuizRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Quizzes>> GetAllQuizzesAsync(int userId)
        {
            return await _db.Quizzes
                .Where(n => n.UserID == userId)
                .ToListAsync();
        }

        public async Task<Quizzes?> GetQuizAsync(int Id, int userId)
        {
            return await _db.Quizzes
                .Where(n => n.Id == Id && n.UserID == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<Quizzes?> AddQuizAsync(Quizzes quiz)
        {
            _db.Quizzes.Add(quiz);
            await _db.SaveChangesAsync();
            return quiz;
        }

        public async Task<Quizzes?> UpdateQuizAsync(Quizzes quiz)
        {
            _db.Quizzes.Update(quiz);
            await _db.SaveChangesAsync();
            return quiz;
        }

        public async Task<bool> DeleteQuizAsync(int Id, int userId)
        {
            var quiz = await _db.Quizzes
                .FirstOrDefaultAsync(n => n.Id == Id && n.UserID == userId);
            if (quiz == null) return false;

            _db.Quizzes.Remove(quiz);
            await _db.SaveChangesAsync();
            return true;
        }
        
    }
}   