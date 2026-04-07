using Microsoft.AspNetCore.Mvc;
using CourseApp.Data;
using CourseApp.Models;

namespace CourseApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        public IActionResult Details(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();
            return View(course);
        }
        public IActionResult StudentCourseTable(int studentId, int courseId)
        {
            var enrollments = _context.Enrollments
                .Where(e => e.StudentId == studentId && e.CourseId == courseId)
                .Select(e => new StudentCourseViewModel
                {
                    StudentName = e.Student.Name,
                    CourseName = e.Course.Name,
                    Degree = e.Degree,
                    Passed = e.Degree >= 50 
                })
                .ToList();

            if (!enrollments.Any())
            {
                return NotFound();
            }

            return View(enrollments);
        }
}
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Course course)
        {
            if (id != course.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}