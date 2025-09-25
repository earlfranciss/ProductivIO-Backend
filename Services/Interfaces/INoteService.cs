using ProductivIOBackend.DTOs;

namespace ProductivIOBackend.Services.Interfaces
{
    public interface INoteService
    {
        Task<NoteResponse> CreateNote(NoteRequest noteRequest);
    }
}