using System.Collections.Generic;
using System.Threading.Tasks;
using ForkliftQuiz.Core.Entities;

namespace ForkliftQuiz.Application.Interfaces
{
    public interface IAnswerRepository
    {
        Task<Answer> GetByIdAsync(int id);
        Task<IEnumerable<Answer>> GetAnswersByQuestionIdAsync(int questionId);
        Task AddAsync(Answer answer);
        Task UpdateAsync(Answer answer);
        Task DeleteAsync(int id);
        Task<IEnumerable<Answer>> GetAllAsync();
    }
}
