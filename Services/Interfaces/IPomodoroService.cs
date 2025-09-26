using ProductivIOBackend.DTOs;

namespace ProductivIOBackend.Services.Interfaces
{
    public interface IPomodoroService
    {
        Task<NoteResponse> CreateNote(NoteRequest noteRequest);
    }
}