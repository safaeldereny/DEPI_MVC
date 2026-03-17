using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        public StudentController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult ShowAll()
        {
            var students = _db.Students.ToList();
            return View(students);
        }

        public IActionResult ShowDetails(int id)
        {
            var student = _db.Students
                .Include(s => s.Department)
                .Include(s => s.StuCrsRes)
                    .ThenInclude(sc => sc.Course)
                .FirstOrDefault(s => s.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }
    }
}