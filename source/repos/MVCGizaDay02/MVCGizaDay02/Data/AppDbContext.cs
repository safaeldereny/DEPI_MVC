using Microsoft.EntityFrameworkCore;
using MVCGizaDay02.Models;

namespace MVCGizaDay02.Data;
public class AppDbContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<StuCrsRes> StuCrsRes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StuCrsRes>()
            .HasKey(x => new { x.StudentId, x.CourseId });

        modelBuilder.Entity<StuCrsRes>()
            .HasOne(x => x.Student)
            .WithMany(s => s.StuCrsRes)
            .HasForeignKey(x => x.StudentId);

        modelBuilder.Entity<StuCrsRes>()
            .HasOne(x => x.Course)
            .WithMany(c => c.StuCrsRes)
            .HasForeignKey(x => x.CourseId);

        modelBuilder.Entity<Teacher>()
            .Property(t => t.Salary)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Department)
            .WithMany(d => d.Teachers)
            .HasForeignKey(t => t.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Student>()
             .HasOne(s => s.Department)
             .WithMany(d => d.Students)
             .HasForeignKey(s => s.DepartmentId)
             .OnDelete(DeleteBehavior.NoAction);
    }
}


