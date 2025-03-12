
namespace Application.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DoctorTypeId { get; set; }

        public string Department { get; set; } = string.Empty;        
        public string Specialization { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;


    }
    
    // DTOs for creating and updating doctor types
    public class CreateDoctorDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DoctorTypeId { get; set; }

        public string Department { get; set; } = string.Empty;        
        public string Specialization { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

    }
    
    public class UpdateDoctorDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DoctorTypeId { get; set; }

        public string Department { get; set; } = string.Empty;        
        public string Specialization { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}