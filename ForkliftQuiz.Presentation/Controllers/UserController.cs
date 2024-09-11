using ForkliftQuiz.Application.DTOs;
using ForkliftQuiz.Application.Interfaces;
using ForkliftQuiz.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
    {
        var result = await _userService.RegisterUserAsync(registerUserDto);

        if (!result.Success)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
    {
        var result = await _userService.LoginUserAsync(loginUserDto);

        if (!result.Success)
        {
            return Unauthorized(result.Errors);
        }

        return Ok(new { Token = result.Token });
    }
}
