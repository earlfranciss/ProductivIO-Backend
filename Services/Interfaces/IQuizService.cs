using ProductivIOBackend.DTOs;

namespace ProductivIOBackend.Services.Interfaces
{
    public interface IQuizService
    {
        Task<NoteResponse> CreateNote(NoteRequest noteRequest);
    }
}