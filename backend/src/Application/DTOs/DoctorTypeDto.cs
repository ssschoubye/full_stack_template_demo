
namespace Application.DTOs
{
    public class DoctorTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
    
    // DTO for creating and updating doctor types
    public class CreateDoctorTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
    
    public class UpdateDoctorTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
}