using ProductivIOBackend.DTOs;

namespace ProductivIOBackend.Services.Interfaces
{
    public interface ITaskService
    {
        Task<NoteResponse> CreateNote(NoteRequest noteRequest);
    }
}