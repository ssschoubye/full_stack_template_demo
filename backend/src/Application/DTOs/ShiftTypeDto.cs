
namespace Application.DTOs
{
    public class ShiftTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Color { get; set; } = "#000000"; 
    }
    
    // DTO for creating and updating Shift types
    public class CreateShiftTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Color { get; set; } = "#000000"; 
    }
    
    public class UpdateShiftTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Color { get; set; } = "#000000"; 
    }
}