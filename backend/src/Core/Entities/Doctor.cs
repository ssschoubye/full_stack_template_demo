namespace Core.Entities
{
    public class Doctor{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int DoctorTypeId { get; set; }

        public DoctorType? DoctorType { get; set; }

    }
}