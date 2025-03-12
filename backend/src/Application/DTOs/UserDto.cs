
namespace Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
    
    // DTO for creating and updating doctor types
    public class CreateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
    
    public class UpdateUserDto
    {

        public string Email { get; set; } = string.Empty;
    }
}