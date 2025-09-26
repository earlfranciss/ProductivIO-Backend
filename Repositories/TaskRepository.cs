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
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _db;

        public TaskRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Tasks>> GetAllTasksAsync(int userId)
        {
            return await _db.Tasks
                .Where(n => n.UserID == userId)
                .ToListAsync();
        }

        public async Task<Tasks?> GetTaskAsync(int Id, int userId)
        {
            return await _db.Tasks
                .Where(n => n.Id == Id && n.UserID == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<Tasks?> AddTaskAsync(Tasks task)
        {
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
            return task;
        }

        public async Task<Tasks?> UpdateTaskAsync(Tasks task)
        {
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTaskAsync(int Id, int userId)
        {
            var task = await _db.Tasks
                .FirstOrDefaultAsync(n => n.Id == Id && n.UserID == userId);
            if (task == null) return false;

            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
            return true;
        }
        
    }
}   