using Moq;
using Xunit;
using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ForkliftQuiz.Core.Interfaces;
using ForkliftQuiz.Application.DTOs;

public class UpdateQuizTests
{
    private readonly Mock<IQuizService> _quizServiceMock;
    private readonly QuizController _controller;

    public UpdateQuizTests()
    {
        _quizServiceMock = new Mock<IQuizService>();
        _controller = new QuizController(_quizServiceMock.Object);
    }

    [Fact]
    public async Task UpdateQuiz_ValidUpdate_ReturnsOkResult()
    {
        // Arrange
        var updateQuizDto = new UpdateQuizDto
        {
            Title = "Updated Title",
            Description = "Updated Description",
            Questions = new List<UpdateQuestionDto>
            {
                new UpdateQuestionDto
                {
                    Text = "Question 1",
                    Answers = new List<UpdateAnswerDto>
                    {
                        new UpdateAnswerDto { Text = "Answer 1", IsCorrect = true }
                    }
                }
            }
        };

        var existingQuiz = new Quiz
        {
            Id = 1,
            Title = "Original Title",
            Description = "Original Description",
            Questions = new List<Question>
            {
                new Question
                {
                    Text = "Original Question",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Original Answer", IsCorrect = false }
                    }
                }
            }
        };

        _quizServiceMock.Setup(s => s.GetQuizByIdAsync(It.IsAny<int>())).ReturnsAsync(existingQuiz);
        _quizServiceMock.Setup(s => s.UpdateQuizAsync(It.IsAny<Quiz>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.UpdateQuiz(1, updateQuizDto);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task UpdateQuiz_QuizDoesNotExist_ReturnsNotFoundResult()
    {
        // Arrange
        var quizId = 999;
        _quizServiceMock.Setup(s => s.GetQuizByIdAsync(quizId)).ReturnsAsync((Quiz)null);
        _quizServiceMock.Setup(s => s.UpdateQuizAsync(It.IsAny<Quiz>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.UpdateQuiz(quizId, new UpdateQuizDto());

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal(404, notFoundResult.StatusCode);
    }
}
