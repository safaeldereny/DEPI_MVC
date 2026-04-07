namespace CourseApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }
}