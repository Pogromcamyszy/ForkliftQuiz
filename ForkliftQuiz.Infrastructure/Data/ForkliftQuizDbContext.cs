using ForkliftQuiz.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForkliftQuiz.Infrastructure.Data
{
    public class ForkliftQuizDbContext : DbContext
    {
        public ForkliftQuizDbContext(DbContextOptions<ForkliftQuizDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
