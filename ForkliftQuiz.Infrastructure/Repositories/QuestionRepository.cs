using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ForkliftQuiz.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ForkliftQuizDbContext _context;

        public QuestionRepository(ForkliftQuizDbContext context)
        {
            _context = context;
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsByQuizIdAsync(int quizId)
        {
            return await _context.Questions.Where(q => q.QuizId == quizId).ToListAsync();
        }

        public async Task AddAsync(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
        }
    }
}
