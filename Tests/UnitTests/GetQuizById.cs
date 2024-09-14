using Moq;
using Xunit;
using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ForkliftQuiz.Core.Interfaces;
using ForkliftQuiz.Core.DTOs;

public class QuizControllerTests
{
    private readonly Mock<IQuizService> _quizServiceMock;
    private readonly QuizController _quizController;

    public QuizControllerTests()
    {
        _quizServiceMock = new Mock<IQuizService>();
        _quizController = new QuizController(_quizServiceMock.Object);
    }

    [Fact]
    public async Task GetQuizById_QuizExists_ReturnsOkResult()
    {
        // Arrange
        var quizId = 1;
        var quiz = new Quiz
        {
            Id = quizId,
            Title = "Sample Quiz",
            Questions = new List<Question>
        {
            new Question
            {
                Id = 1,
                Text = "Sample Question",
                Answers = new List<Answer>
                {
                    new Answer { Id = 1, Text = "Answer 1", IsCorrect = true },
                    new Answer { Id = 2, Text = "Answer 2", IsCorrect = false }
                }
            }
        }
        };
        _quizServiceMock.Setup(s => s.GetQuizByIdWithDetailsAsync(quizId)).ReturnsAsync(quiz);

        // Act
        var result = await _quizController.GetQuizById(quizId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedQuiz = Assert.IsType<QuizDto>(okResult.Value);
        Assert.Equal("Sample Quiz", returnedQuiz.Title);
    }


}
