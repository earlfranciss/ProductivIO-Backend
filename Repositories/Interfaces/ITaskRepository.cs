using ProductivIOBackend.DTOs;
using ProductivIOBackend.Models;

namespace ProductivIOBackend.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Tasks>> GetAllTasksAsync(int userId);
        Task<Tasks?> GetTaskAsync(int Id, int userId);
        Task<Tasks?> UpdateTaskAsync(Tasks task);
        Task<Tasks?> AddTaskAsync(Tasks task);
        Task<bool> DeleteTaskAsync(int Id, int userId);
    }
}