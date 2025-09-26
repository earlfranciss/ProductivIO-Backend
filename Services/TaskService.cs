using System.Threading.Tasks;
using ProductivIOBackend.DTOs;
using ProductivIOBackend.Services.Interfaces;

namespace ProductivIOBackend.Services
{
    public class TaskService : ITaskService
    {
        public async Task<NoteResponse> CreateNote(NoteRequest noteRequest)
        {
            return new NoteResponse { };
        }
    }
}