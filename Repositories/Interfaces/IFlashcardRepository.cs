using ProductivIOBackend.DTOs;
using ProductivIOBackend.Models;

namespace ProductivIOBackend.Repositories.Interfaces
{
    public interface IFlashcardRepository
    {
        Task<List<Flashcards>> GetAllFlashcardsAsync(int userId);
        Task<Flashcards?> GetFlashcardAsync(int Id, int userId);
        Task<Flashcards?> UpdateFlashcardAsync(Flashcards flashcard);
        Task<Flashcards?> AddFlashcardAsync(Flashcards flashcard);
        Task<bool> DeleteFlashcardAsync(int Id, int userId);
    }
}