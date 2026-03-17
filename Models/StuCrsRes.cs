using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Models
{
    public class StuCrsRes
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}