using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForkliftQuiz.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _questionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsByQuizIdAsync(int quizId)
        {
            return await _questionRepository.GetQuestionsByQuizIdAsync(quizId);
        }

        public async Task CreateQuestionAsync(Question question)
        {
            await _questionRepository.AddAsync(question);
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            await _questionRepository.UpdateAsync(question);
        }

        public async Task DeleteQuestionAsync(int id)
        {
            await _questionRepository.DeleteAsync(id);
        }
    }
}
