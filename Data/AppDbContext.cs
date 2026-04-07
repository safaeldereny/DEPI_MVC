using Microsoft.EntityFrameworkCore;
using CourseApp.Models;
namespace CourseApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}