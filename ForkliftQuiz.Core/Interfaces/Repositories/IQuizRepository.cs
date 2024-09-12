using System.Collections.Generic;
using System.Threading.Tasks;
using ForkliftQuiz.Core.Entities;

namespace ForkliftQuiz.Application.Interfaces
{
    public interface IQuizRepository
    {
        Task<Quiz> GetByIdAsync(int id);
        Task<IEnumerable<Quiz>> GetAllAsync();
        Task AddAsync(Quiz quiz);
        Task UpdateAsync(Quiz quiz);
        Task DeleteAsync(int id);
        Task<Quiz> GetQuizByIdWithDetailsAsync(int id);

    }
}
