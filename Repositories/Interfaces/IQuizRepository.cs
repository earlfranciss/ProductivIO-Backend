using ProductivIOBackend.DTOs;
using ProductivIOBackend.Models;

namespace ProductivIOBackend.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<List<Quizzes>> GetAllQuizzesAsync(int userId);
        Task<Quizzes?> GetQuizAsync(int Id, int userId);
        Task<Quizzes?> UpdateQuizAsync(Quizzes quiz);
        Task<Quizzes?> AddQuizAsync(Quizzes quiz);
        Task<bool> DeleteQuizAsync(int Id, int userId);
    }
}