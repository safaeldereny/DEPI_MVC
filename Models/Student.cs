using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<StuCrsRes> StuCrsRes { get; set; }
    }
}