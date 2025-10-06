using ProductivIOBackend.Models;

namespace ProductivIOBackend.Models
{
    public class QuizResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }

        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }

        public DateTime TakenAt { get; set; } = DateTime.UtcNow;

        
        public User User { get; set; } = null!;
        public Quizzes Quiz { get; set; } = null!;
        public List<QuizResultAnswer> ResultAnswers { get; set; } = new();
    }

    public class QuizResultAnswer
    {
        public int Id { get; set; }
        public int QuizResultId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }

        public bool IsCorrect { get; set; }

        public QuizResult QuizResult { get; set; } = null!;
        public QuizQuestion Question { get; set; } = null!;
        public QuizAnswer Answer { get; set; } = null!;
    }
}