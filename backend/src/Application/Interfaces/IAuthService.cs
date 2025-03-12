

namespace Application.Interfaces
{
    public class LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResultDto
    {
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }

    public interface IAuthService
    {
        Task<AuthResultDto> LoginAsync(LoginDto loginDto);
    }
}