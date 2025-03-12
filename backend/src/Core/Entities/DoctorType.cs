namespace Core.Entities
{
    public class DoctorType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = "#000000"; 
        

        public ICollection<Doctor>? Doctors { get; set; }
    }
}