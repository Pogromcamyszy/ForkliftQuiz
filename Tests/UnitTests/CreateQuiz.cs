using Moq;
using Xunit;
using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ForkliftQuiz.Core.Interfaces;
using ForkliftQuiz.Core.DTOs;

public class CreateQuizTests
{
    private readonly Mock<IQuizService> _quizServiceMock;
    private readonly QuizController _controller;

    public CreateQuizTests()
    {
        _quizServiceMock = new Mock<IQuizService>();
        _controller = new QuizController(_quizServiceMock.Object);
    }

    [Fact]
    public async Task DeleteQuiz_QuizDoesNotExist_ReturnsNotFoundResult()
    {
        // Arrange
        _quizServiceMock.Setup(s => s.GetQuizByIdAsync(It.IsAny<int>())).ReturnsAsync((Quiz)null);

        // Act
        var result = await _controller.DeleteQuiz(1);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public async Task DeleteQuiz_QuizExists_ReturnsOkResult()
    {
        // Arrange
        var quiz = new Quiz { Id = 1, Title = "Test Quiz" };
        _quizServiceMock.Setup(s => s.GetQuizByIdAsync(It.IsAny<int>())).ReturnsAsync(quiz);

        // Act
        var result = await _controller.DeleteQuiz(1);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
