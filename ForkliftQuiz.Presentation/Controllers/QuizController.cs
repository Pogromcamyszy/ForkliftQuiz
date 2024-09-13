using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Core.Interfaces;
using ForkliftQuiz.Core.DTOs;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuizById(int id)
    {
        var quiz = await _quizService.GetQuizByIdWithDetailsAsync(id);
        if (quiz == null)
        {
            return NotFound();
        }

        var quizDto = new QuizDto
        {
            Id = quiz.Id,
            Title = quiz.Title,
            Description = quiz.Description,
            Questions = quiz.Questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                Text = q.Text,
                Answers = q.Answers.Select(a => new AnswerDto
                {
                    Id = a.Id,
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList()
            }).ToList()
        };

        return Ok(quizDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizDto createQuizDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userIdClaim = User.FindFirst(ClaimTypes.Name);
        if (userIdClaim == null)
        {
            return Unauthorized("Brak identyfikatora użytkownika.");
        }

        var userId = int.Parse(userIdClaim.Value);

        var quiz = new Quiz
        {
            Title = createQuizDto.Title,
            Description = createQuizDto.Description,
            UserId = userId, 
            Questions = createQuizDto.Questions.Select(q => new Question
            {
                Text = q.Text,
                Answers = q.Answers.Select(a => new Answer
                {
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList()
            }).ToList()
        };

        await _quizService.CreateQuizAsync(quiz);

        return Ok(quiz);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuiz(int id, [FromBody] UpdateQuizDto updateQuizDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingQuiz = await _quizService.GetQuizByIdAsync(id);
        if (existingQuiz == null)
        {
            return NotFound("Quiz not found.");
        }

        existingQuiz.Title = updateQuizDto.Title;
        existingQuiz.Description = updateQuizDto.Description;

        if (existingQuiz.Questions != null && updateQuizDto.Questions != null)
        {
            foreach (var updateQuestion in updateQuizDto.Questions)
            {
                var existingQuestion = existingQuiz.Questions.FirstOrDefault(q => q.Id == updateQuestion.Id);
                if (existingQuestion != null)
                {
                    existingQuestion.Text = updateQuestion.Text;

                     if (existingQuestion.Answers != null && updateQuestion.Answers != null)
                    {
                        foreach (var updateAnswer in updateQuestion.Answers)
                        {
                            var existingAnswer = existingQuestion.Answers.FirstOrDefault(a => a.Id == updateAnswer.Id);
                            if (existingAnswer != null)
                            {
                                existingAnswer.Text = updateAnswer.Text;
                                existingAnswer.IsCorrect = updateAnswer.IsCorrect;
                            }
                        }
                    }
                }
            }
        }

        await _quizService.UpdateQuizAsync(existingQuiz);

        return Ok();
    }


    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuiz(int id)
    {
        var quiz = await _quizService.GetQuizByIdAsync(id);
        if (quiz == null)
        {
            return NotFound("Quiz not found.");
        }

        await _quizService.DeleteQuizAsync(id);

        return Ok("Quiz deleted successfully.");
    }

    private Quiz ConvertToQuizEntity(UpdateQuizDto updateQuizDto)
    {
        return new Quiz
        {
            Title = updateQuizDto.Title,
            Description = updateQuizDto.Description,
            Questions = updateQuizDto.Questions.Select(q => new Question
            {
                Text = q.Text,
                Answers = q.Answers.Select(a => new Answer
                {
                    Text = a.Text,
                    IsCorrect = a.IsCorrect
                }).ToList()
            }).ToList()
        };
    }
}
