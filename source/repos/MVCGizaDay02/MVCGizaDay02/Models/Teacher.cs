namespace MVCGizaDay02.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
