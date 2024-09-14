using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Infrastructure.Data;
using ForkliftQuiz.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class QuizServiceIntegrationTests
{
    private readonly QuizRepository _quizRepository;
    private readonly ForkliftQuizDbContext _dbContext;

    public QuizServiceIntegrationTests()
    {
        var options = new DbContextOptionsBuilder<ForkliftQuizDbContext>()
            .UseInMemoryDatabase(databaseName: "QuizTestDb")
            .Options;

        _dbContext = new ForkliftQuizDbContext(options);
        _quizRepository = new QuizRepository(_dbContext);
    }

    [Fact]
    public async Task CreateQuiz_SavesQuizToDatabase()
    {
        // Arrange
        var quiz = new Quiz
        {
            Title = "Integration Test Quiz",
            Description = "Integration Test Description",
            Questions = new List<Question>
            {
                new Question
                {
                    Text = "Question 1",
                    Answers = new List<Answer>
                    {
                        new Answer { Text = "Answer 1", IsCorrect = true }
                    }
                }
            }
        };

        // Act
        await _quizRepository.AddAsync(quiz);
        var savedQuiz = await _quizRepository.GetQuizByIdWithDetailsAsync(quiz.Id);

        // Assert
        Assert.NotNull(savedQuiz);
        Assert.Equal("Integration Test Quiz", savedQuiz.Title);
        Assert.Single(savedQuiz.Questions);
    }
}
