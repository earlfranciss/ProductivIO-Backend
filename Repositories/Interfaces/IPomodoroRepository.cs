using ProductivIOBackend.DTOs;
using ProductivIOBackend.Models;

namespace ProductivIOBackend.Repositories.Interfaces
{
    public interface IPomodoroRepository
    {
        Task<List<Pomodoro>> GetAllPomodoroAsync(int userId);
        Task<Pomodoro?> GetPomodoroAsync(int Id, int userId);
        Task<Pomodoro?> UpdatePomodoroAsync(Pomodoro pomodoro);
        Task<Pomodoro?> AddPomodoroAsync(Pomodoro pomodoro);
        Task<bool> DeletePomodoroAsync(int Id, int userId);
    }
}