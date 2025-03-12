namespace Core.Entities
{
    public class ShiftType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Color { get; set; } = "#000000"; 
    }
}