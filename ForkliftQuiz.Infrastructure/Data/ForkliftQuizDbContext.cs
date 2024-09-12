using ForkliftQuiz.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForkliftQuiz.Infrastructure.Data
{
    public class ForkliftQuizDbContext : DbContext
    {
        public ForkliftQuizDbContext(DbContextOptions<ForkliftQuizDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding Users with Email property
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "admin", Email = "admin@example.com", PasswordHash = "hashed_password", Role = "Admin" },
                new User { Id = 2, UserName = "user1", Email = "user1@example.com", PasswordHash = "hashed_password1", Role = "User" }
            );

            // Seeding Quizzes
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz { Id = 1, Title = "Forklift Safety Quiz", Description = "A quiz about forklift safety practices.", UserId = 1 },
                new Quiz { Id = 2, Title = "Advanced Forklift Operations", Description = "A quiz for advanced forklift operations.", UserId = 2 }
            );

            // Seeding Questions
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, QuizId = 1, Text = "What is the maximum load a forklift can carry?" },
                new Question { Id = 2, QuizId = 1, Text = "How often should forklifts be inspected?" }
            );

            // Seeding Answers
            modelBuilder.Entity<Answer>().HasData(
                new Answer { Id = 1, QuestionId = 1, Text = "2000kg", IsCorrect = true },
                new Answer { Id = 2, QuestionId = 1, Text = "5000kg", IsCorrect = false },
                new Answer { Id = 3, QuestionId = 2, Text = "Daily", IsCorrect = true },
                new Answer { Id = 4, QuestionId = 2, Text = "Weekly", IsCorrect = false }
            );
        }
    }
}
