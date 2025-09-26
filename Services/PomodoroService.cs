using System.Threading.Tasks;
using ProductivIOBackend.DTOs;
using ProductivIOBackend.Services.Interfaces;

namespace ProductivIOBackend.Services
{
    public class PomodoroService : IPomodoroService
    {
        public async Task<NoteResponse> CreateNote(NoteRequest noteRequest)
        {
            return new NoteResponse { };
        }
    }
}