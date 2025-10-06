using Microsoft.AspNetCore.Mvc;
using ProductivIOBackend.DTOs.Pomodoro;
using ProductivIOBackend.Models;
using ProductivIOBackend.Services.Interfaces;
using System.Threading.Tasks;

namespace ProductivIOBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PomodoroController : ControllerBase
    {
        private readonly IPomodoroService _pomodoroService;

        public PomodoroController(IPomodoroService pomodoroService)
        {
            _pomodoroService = pomodoroService;
        }

        // GET: api/Pomodoro/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAll(int userId)
        {
            var pomodoros = await _pomodoroService.GetAll(userId);
            return Ok(pomodoros);
        }

        // GET: api/Pomodoro/{id}/user/{userId}
        [HttpGet("{id}/user/{userId}")]
        public async Task<IActionResult> Get(int id, int userId)
        {
            var pomodoro = await _pomodoroService.Get(id, userId);
            if (pomodoro == null)
                return NotFound(new { message = "Pomodoro session not found." });

            return Ok(pomodoro);
        }

        // POST: api/Pomodoro
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PomodoroDto pomodoro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _pomodoroService.Create(pomodoro);
            if (created == null)
                return BadRequest(new { message = "Could not create Pomodoro session." });

            return CreatedAtAction(nameof(Get), new { id = created.Id, userId = created.UserID }, created);
        }

        // PUT: api/Pomodoro/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PomodoroDto pomodoro)
        {
            if (id != pomodoro.Id)
                return BadRequest(new { message = "Pomodoro ID mismatch." });

            var updated = await _pomodoroService.Update(id, pomodoro);
            if (!updated)
                return NotFound(new { message = "Pomodoro session not found for update." });

            return Ok(new { message = "Pomodoro updated successfully." });
        }

        // DELETE: api/Pomodoro/{id}/user/{userId}
        [HttpDelete("{id}/user/{userId}")]
        public async Task<IActionResult> Delete(int id, int userId)
        {
            var deleted = await _pomodoroService.Delete(id, userId);
            if (!deleted)
                return NotFound(new { message = "Pomodoro session not found for deletion." });

            return NoContent();
        }

        // GET: api/Pomodoro/user/{userId}/completedSession
        [HttpGet("user/{userId}/completedSession")]
        public async Task<IActionResult> GetCompletedSession(int userId)
        {
            var count = await _pomodoroService.GetCompletedSession(userId);
            return Ok(count);
        }

        // GET: api/Pomodoro/user/{userId}/sessionDuration
        [HttpGet("user/{userId}/sessionDuration")]
        public async Task<IActionResult> GetTotalDuration(int userId)
        {
            var duration = await _pomodoroService.GetTotalDuration(userId);
            return Ok(duration);
        }
    }
}
