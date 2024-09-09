using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Core.Interfaces;
using ForkliftQuiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForkliftQuiz.Infrastructure.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ForkliftQuizDbContext _context;

        public QuizRepository(ForkliftQuizDbContext context)
        {
            _context = context;
        }

        public async Task<Quiz> GetByIdAsync(int id)
        {
            return await _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .SingleOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .ToListAsync();
        }

        public async Task AddAsync(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
                await _context.SaveChangesAsync();
            }
        }
    }
}
