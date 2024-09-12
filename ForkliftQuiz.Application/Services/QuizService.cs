using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForkliftQuiz.Application.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task<Quiz> GetQuizByIdAsync(int id)
        {
            return await _quizRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
        {
            return await _quizRepository.GetAllAsync();
        }

        public async Task CreateQuizAsync(Quiz quiz)
        {
            await _quizRepository.AddAsync(quiz);
        }

        public async Task UpdateQuizAsync(Quiz quiz)
        {
            await _quizRepository.UpdateAsync(quiz);
        }

        public async Task DeleteQuizAsync(int id)
        {
            await _quizRepository.DeleteAsync(id);
        }
        public async Task<Quiz> GetQuizByIdWithDetailsAsync(int id)
        {
            return await _quizRepository.GetQuizByIdWithDetailsAsync(id);
        }

    }
}
