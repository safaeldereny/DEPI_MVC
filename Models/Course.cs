using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Instructor is required")]
        public string Instructor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Duration is required")]
        public string Duration { get; set; } = string.Empty;
    }
}
