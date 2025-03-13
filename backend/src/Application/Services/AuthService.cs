using Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Core.Entities;
using Application.DTOs;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<AuthResultDto> LoginAsync(LoginDto loginDto)
    {
        // Validate user credentials
        var user = await _userRepository.GetByUsernameAsync(loginDto.Username);
        if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid username or password");

        // Generate JWT token
        var token = GenerateJwtToken(user);

        return new AuthResultDto
        {
            Token = token,
            Username = user.Username
        };
    }

    private bool VerifyPassword(string password, string passwordHash)
    {
        // Implement password verification logic (e.g., using BCrypt)
        // For demo purposes only:
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

    private string GenerateJwtToken(User user)
    {
        // Implement JWT token generation
        // You'll need Microsoft.IdentityModel.Tokens and System.IdentityModel.Tokens.Jwt packages
        
        var jwtKey = _configuration["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key configuration is missing");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            },
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<AuthResultDto> RegisterAsync(CreateUserDto createUserDto)
    {
        // Implement user registration logic
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.PasswordHash);

        var user = new User
        {
            Username = createUserDto.Username,
            PasswordHash = passwordHash
        };

        await _userRepository.AddAsync(user);

        // Generate JWT token
        var token = GenerateJwtToken(user);

        return new AuthResultDto
        {
            Token = token,
            Username = user.Username
        };
    }
}