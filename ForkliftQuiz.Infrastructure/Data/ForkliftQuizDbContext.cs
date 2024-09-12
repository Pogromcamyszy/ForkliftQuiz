using ForkliftQuiz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

            // Seeding Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "admin", Email = "admin@example.com", PasswordHash = "hashed_password", Role = "Admin" },
                new User { Id = 2, UserName = "user1", Email = "user1@example.com", PasswordHash = "hashed_password1", Role = "User" }
            );

            // Seeding Quizzes, Questions, and Answers
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 1,
                    Title = "Forklift Safety Quiz",
                    Description = "A quiz about forklift safety practices.",
                    UserId = 1
                },
                new Quiz
                {
                    Id = 2,
                    Title = "General Forklift Operations",
                    Description = "A quiz about the general operations of forklifts.",
                    UserId = 1
                }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Text = "What is the maximum safe speed for a forklift?",
                    QuizId = 1
                },
                new Question
                {
                    Id = 2,
                    Text = "When should a forklift operator wear a seatbelt?",
                    QuizId = 1
                },
                new Question
                {
                    Id = 3,
                    Text = "How often should a forklift be inspected?",
                    QuizId = 2
                },
                new Question
                {
                    Id = 4,
                    Text = "What should you do if you notice a leak in the hydraulic system?",
                    QuizId = 2
                }
            );

            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = 1,
                    Text = "5 mph",
                    IsCorrect = true,
                    QuestionId = 1
                },
                new Answer
                {
                    Id = 2,
                    Text = "10 mph",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new Answer
                {
                    Id = 3,
                    Text = "15 mph",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new Answer
                {
                    Id = 4,
                    Text = "Always",
                    IsCorrect = true,
                    QuestionId = 2
                },
                new Answer
                {
                    Id = 5,
                    Text = "Only when carrying loads",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new Answer
                {
                    Id = 6,
                    Text = "When driving over 5 mph",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new Answer
                {
                    Id = 7,
                    Text = "Daily",
                    IsCorrect = true,
                    QuestionId = 3
                },
                new Answer
                {
                    Id = 8,
                    Text = "Weekly",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new Answer
                {
                    Id = 9,
                    Text = "Monthly",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new Answer
                {
                    Id = 10,
                    Text = "Stop using the forklift and report the issue",
                    IsCorrect = true,
                    QuestionId = 4
                },
                new Answer
                {
                    Id = 11,
                    Text = "Continue working and report it at the end of the shift",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new Answer
                {
                    Id = 12,
                    Text = "Fix it yourself if you have time",
                    IsCorrect = false,
                    QuestionId = 4
                }
            );
        }
    }
}
