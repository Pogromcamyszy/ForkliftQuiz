using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Core.Interfaces;
using ForkliftQuiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForkliftQuiz.Infrastructure.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ForkliftQuizDbContext _context;

        public AnswerRepository(ForkliftQuizDbContext context)
        {
            _context = context;
        }

        public async Task<Answer> GetByIdAsync(int id)
        {
            return await _context.Answers.FindAsync(id);
        }

        public async Task<IEnumerable<Answer>> GetAnswersByQuestionIdAsync(int questionId)
        {
            return await _context.Answers
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task AddAsync(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Answer answer)
        {
            _context.Answers.Update(answer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer != null)
            {
                _context.Answers.Remove(answer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
