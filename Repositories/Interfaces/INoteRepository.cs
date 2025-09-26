using ProductivIOBackend.DTOs;
using ProductivIOBackend.Models;

namespace ProductivIOBackend.Repositories.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Notes>> GetAllNotesAsync(int userId);
        Task<Notes?> GetNoteAsync(int Id, int userId);
        Task<Notes?> UpdateNoteAsync(Notes note);
        Task<Notes?> AddNoteAsync(Notes note);
        Task<bool> DeleteNoteAsync(int Id, int userId);
    }
}