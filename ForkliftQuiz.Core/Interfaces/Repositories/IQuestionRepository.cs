using System.Collections.Generic;
using System.Threading.Tasks;
using ForkliftQuiz.Core.Entities;

namespace ForkliftQuiz.Application.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> GetByIdAsync(int id);
        Task<IEnumerable<Question>> GetQuestionsByQuizIdAsync(int quizId);
        Task AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(int id);
        Task<IEnumerable<Question>> GetAllAsync();
    }
}
