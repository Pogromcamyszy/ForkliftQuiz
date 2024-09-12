using ForkliftQuiz.Application.DTOs;
using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Core.Entities;
using ForkliftQuiz.Core.Interfaces;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ForkliftQuiz.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticationResult> RegisterUserAsync(RegisterUserDto registerUserDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(registerUserDto.Email);
            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = new[] { "User with this email already exists." }
                };
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password);

            var newUser = new User
            {
                UserName = registerUserDto.Email,
                Email = registerUserDto.Email,
                PasswordHash = hashedPassword,
                Role = registerUserDto.Role 
            };

            await _userRepository.AddAsync(newUser);

            var token = _jwtTokenGenerator.GenerateToken(newUser);
            return new AuthenticationResult
            {
                Success = true,
                Token = token
            };
        }


        public async Task<AuthenticationResult> LoginUserAsync(LoginUserDto loginUserDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginUserDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.PasswordHash))
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = new[] { "Invalid login credentials." }
                };
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult
            {
                Success = true,
                Token = token
            };
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
