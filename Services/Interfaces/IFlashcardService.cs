using ProductivIOBackend.DTOs;

namespace ProductivIOBackend.Services.Interfaces
{
    public interface IFlashcardService
    {
        Task<NoteResponse> CreateNote(NoteRequest noteRequest);
    }
}