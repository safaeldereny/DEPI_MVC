using Microsoft.EntityFrameworkCore;
using CourseApp.Models;
using CourseApp.Data;

namespace CourseApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}