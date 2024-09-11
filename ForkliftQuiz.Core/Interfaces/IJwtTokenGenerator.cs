using ForkliftQuiz.Core.Entities;

namespace ForkliftQuiz.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
