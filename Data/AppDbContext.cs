using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StuCrsRes> StuCrsRes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StuCrsRes>()
                .HasKey(x => new { x.StudentId, x.CourseId });

            modelBuilder.Entity<StuCrsRes>()
                .HasOne(s => s.Student)
                .WithMany(s => s.StuCrsRes)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StuCrsRes>()
                .HasOne(s => s.Course)
                .WithMany(c => c.StuCrsRes)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Salary)
                .HasPrecision(18, 2);
        }
    }
}