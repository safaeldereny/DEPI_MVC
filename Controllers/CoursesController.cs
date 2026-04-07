using Microsoft.AspNetCore.Mvc;
using CourseApp.Data; 
using CourseApp.Models;


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
            _context.Update(course);
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
        _context.Courses.Remove(course);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var course = _context.Courses.Find(id);
        if (course == null)
            return NotFound();

        return View(course);
    }
}