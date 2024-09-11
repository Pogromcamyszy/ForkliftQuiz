using ForkliftQuiz.Application;
using ForkliftQuiz.Core.Entities;
using System.Threading.Tasks;
using ForkliftQuiz.Application.DTOs;

namespace ForkliftQuiz.Core.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResult> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<AuthenticationResult> LoginUserAsync(LoginUserDto loginUserDto);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
