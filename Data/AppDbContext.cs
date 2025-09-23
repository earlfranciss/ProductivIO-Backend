using Microsoft.EntityFrameworkCore;
using ProductivIOBackend.Models;

namespace ProductivIOBackend.Data
{
    // AppDbContext: The EF Core gateway to your database
    public class AppDbContext : DbContext
    {
        // This constructor lets ASP.NET inject options (like the connection string)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet<T> maps your model to a table
        public DbSet<User> Users => Set<User>();
        public DbSet<Notes> Notes => Set<Notes>();
        public DbSet<Tasks> Tasks => Set<Tasks>();
        public DbSet<Pomodoro> Pomodoros => Set<Pomodoro>();
        public DbSet<Flashcards> Flashcards => Set<Flashcards>();
        public DbSet<FlashcardQuestion> FlashcardQuestions => Set<FlashcardQuestion>();
        public DbSet<FlashcardAnswer> FlashcardAnswers => Set<FlashcardAnswer>();
        public DbSet<Quizzes> Quizzes => Set<Quizzes>();
        public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
        public DbSet<QuizAnswer> QuizAnswers => Set<QuizAnswer>();
    }
}
