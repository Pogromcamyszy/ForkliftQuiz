using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Core.Interfaces;
using ForkliftQuiz.Core.DTOs;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    // Get a quiz by its ID including questions and answers
    [HttpGet("{id}")]
    public async Task<IActionResult> GetQuizById(int id)
    {
        var quiz = await _quizService.GetQuizByIdWithDetailsAsync(id);
        if (quiz == null)
        {
            return NotFound();
        }

        // Map entity to DTO to control what is returned
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

        var quizEntity = ConvertToQuizEntity(createQuizDto);
        await _quizService.CreateQuizAsync(quizEntity);

        return Ok();
    }

    private Quiz ConvertToQuizEntity(CreateQuizDto createQuizDto)
    {
        return new Quiz
        {
            Title = createQuizDto.Title,
            Description = createQuizDto.Description,
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
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuiz(int id, [FromBody] UpdateQuizDto updateQuizDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var quizEntity = ConvertToQuizEntity(updateQuizDto);
        await _quizService.UpdateQuizAsync(quizEntity);

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
