using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ForkliftQuiz.Core.Interfaces;

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
        var quiz = await _quizService.GetQuizByIdAsync(id);
        if (quiz == null)
        {
            return NotFound();
        }

        return Ok(quiz);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateQuiz([FromBody] CreateQuizDto createQuizDto)
    {
        var result = await _quizService.CreateQuizAsync(createQuizDto);
        if (!result.Success)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuiz(int id, [FromBody] UpdateQuizDto updateQuizDto)
    {
        var result = await _quizService.UpdateQuizAsync(id, updateQuizDto);
        if (!result.Success)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuiz(int id)
    {
        var result = await _quizService.DeleteQuizAsync(id);
        if (!result.Success)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result);
    }
}
