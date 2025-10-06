using Microsoft.AspNetCore.Mvc;
using ProductivIOBackend.Models;
using ProductivIOBackend.Services.Interfaces;
using ProductivIOBackend.DTOs.Quiz;

namespace ProductivIOBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }


        // --- Quizzes ---
        // GET: /api/Quiz/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllQuizzes(int userId)
        {
            var quizzes = await _quizService.GetAllQuizzes(userId);
            return Ok(quizzes);
        }

        // GET: /api/Quiz/{id}/user/{userId}
        [HttpGet("{id}/user/{userId}")]
        public async Task<IActionResult> GetQuiz(int id, int userId)
        {
            var quiz = await _quizService.GetQuiz(id, userId);
            if (quiz == null) return NotFound(new { message = "Quiz not found." });
            return Ok(quiz);
        }

        // POST: /api/Quiz
        [HttpPost]
        public async Task<IActionResult> AddQuiz([FromBody] QuizzesDto quiz)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _quizService.AddQuiz(quiz);
            if (created == null) return BadRequest(new { message = "Failed to create quiz." });

            return CreatedAtAction(nameof(GetQuiz), new { id = created.Id, userId = created.UserID }, created);
        }

        // PUT: /api/Quiz/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuiz(int id, [FromBody] QuizzesDto quiz)
        {
            if (id != quiz.Id) return BadRequest(new { message = "Quiz ID mismatch." });

            var updated = await _quizService.UpdateQuiz(id, quiz);
            if (!updated) return NotFound(new { message = "Quiz not found or could not be updated." });

            return NoContent();
        }

        // DELETE: /api/Quiz/{id}/user/{userId}
        [HttpDelete("{id}/user/{userId}")]
        public async Task<IActionResult> DeleteQuiz(int id, int userId)
        {
            var deleted = await _quizService.DeleteQuiz(id, userId);
            if (!deleted) return NotFound(new { message = "Quiz not found or could not be deleted." });

            return NoContent();
        }

        // POST: /api/Quiz/{quizId}/questions
        [HttpPost("{quizId}/questions")]
        public async Task<IActionResult> AddQuestion(int quizId, [FromBody] QuizQuestionDto question)
        {
            var created = await _quizService.AddQuestion(quizId, question);
            if (created == null) return BadRequest(new { message = "Failed to add question." });

            return Ok(created);
        }


        // --- Questions ---
        // PUT: /api/Quiz/{quizId}/questions/{questionId}
        [HttpPut("{quizId}/questions/{questionId}")]
        public async Task<IActionResult> UpdateQuestion(int quizId, int questionId, [FromBody] QuizQuestionDto question)
        {
            if (questionId != question.Id) return BadRequest(new { message = "Question ID mismatch." });

            var updated = await _quizService.UpdateQuestion(quizId, question);
            if (!updated) return NotFound(new { message = "Question not found or could not be updated." });

            return NoContent();
        }

        // DELETE: /api/Quiz/questions/{questionId}
        [HttpDelete("questions/{questionId}")]
        public async Task<IActionResult> DeleteQuestion(int questionId)
        {
            var deleted = await _quizService.DeleteQuestion(questionId);
            if (!deleted) return NotFound(new { message = "Question not found or could not be deleted." });

            return NoContent();
        }

        // --- Answers ---
        // POST: /api/Quiz/questions/{questionId}/answers
        [HttpPost("questions/{questionId}/answers")]
        public async Task<IActionResult> AddAnswer(int questionId, [FromBody] QuizAnswerDto answer)
        {
            var created = await _quizService.AddAnswer(questionId, answer);
            if (created == null) return BadRequest(new { message = "Failed to add answer." });

            return Ok(created);
        }

        // PUT: /api/Quiz/questions/{questionId}/answers/{answerId}
        [HttpPut("questions/{questionId}/answers/{answerId}")]
        public async Task<IActionResult> UpdateAnswer(int questionId, int answerId, [FromBody] QuizAnswerDto answer)
        {
            if (answerId != answer.Id) return BadRequest(new { message = "Answer ID mismatch." });

            var updated = await _quizService.UpdateAnswer(questionId, answer);
            if (!updated) return NotFound(new { message = "Answer not found or could not be updated." });

            return NoContent();
        }

        // DELETE: /api/Quiz/answers/{answerId}
        [HttpDelete("answers/{answerId}")]
        public async Task<IActionResult> DeleteAnswer(int answerId)
        {
            var deleted = await _quizService.DeleteAnswer(answerId);
            if (!deleted) return NotFound(new { message = "Answer not found or could not be deleted." });

            return NoContent();
        }
    }
}
