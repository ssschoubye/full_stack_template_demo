using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResultDto>> Login(LoginDto loginDto)
        {
            try
            {
                var result = await _authService.LoginAsync(loginDto);
                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid username or password");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred during authentication: " + ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResultDto>> Register(CreateUserDto createUserDto)
        {
            try
            {
                var result = await _authService.RegisterAsync(createUserDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred during registration" + ex.Message);
            }
        }
    }
}