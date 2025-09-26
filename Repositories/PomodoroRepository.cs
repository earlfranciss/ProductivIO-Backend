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
    public class PomodoroRepository : IPomodoroRepository
    {
        private readonly AppDbContext _db;

        public PomodoroRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Pomodoro>> GetAllPomodoroAsync(int userId)
        {
            return await _db.Pomodoros
                .Where(n => n.UserID == userId)
                .ToListAsync();
        }

        public async Task<Pomodoro?> GetPomodoroAsync(int Id, int userId)
        {
            return await _db.Pomodoros
                .Where(n => n.Id == Id && n.UserID == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<Pomodoro?> AddPomodoroAsync(Pomodoro pomodoro)
        {
            _db.Pomodoros.Add(pomodoro);
            await _db.SaveChangesAsync();
            return pomodoro;
        }

        public async Task<Pomodoro?> UpdatePomodoroAsync(Pomodoro pomodoro)
        {
            _db.Pomodoros.Update(pomodoro);
            await _db.SaveChangesAsync();
            return pomodoro;
        }

        public async Task<bool> DeletePomodoroAsync(int Id, int userId)
        {
            var pomodoro = await _db.Pomodoros
                .FirstOrDefaultAsync(n => n.Id == Id && n.UserID == userId);
            if (pomodoro == null) return false;

            _db.Pomodoros.Remove(pomodoro);
            await _db.SaveChangesAsync();
            return true;
        }
        
    }
}   