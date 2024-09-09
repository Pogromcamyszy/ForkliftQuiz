using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForkliftQuiz.Application.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Answer> GetAnswerByIdAsync(int id)
        {
            return await _answerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Answer>> GetAnswersByQuestionIdAsync(int questionId)
        {
            return await _answerRepository.GetAnswersByQuestionIdAsync(questionId);
        }

        public async Task CreateAnswerAsync(Answer answer)
        {
            await _answerRepository.AddAsync(answer);
        }

        public async Task UpdateAnswerAsync(Answer answer)
        {
            await _answerRepository.UpdateAsync(answer);
        }

        public async Task DeleteAnswerAsync(int id)
        {
            await _answerRepository.DeleteAsync(id);
        }
    }
}
