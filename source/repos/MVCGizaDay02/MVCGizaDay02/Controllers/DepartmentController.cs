using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCGizaDay02.Data;
using MVCGizaDay02.Models;
using MVCGizaDay02.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public DepartmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("ShowAll")]
    public async Task<IActionResult> ShowAll()
    {
        var departments = await _context.Departments.ToListAsync();
        return Ok(departments);
    }

    [HttpGet("ShowDetails/{id}")]
    public async Task<IActionResult> ShowDetails(int id)
    {
        var department = await _context.Departments
            .Include(d => d.Students)
            .Include(d => d.Courses)
            .Include(d => d.Teachers)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (department == null)
            return NotFound($"Department with Id {id} not found.");

        return Ok(department);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] Department department)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(ShowDetails), new { id = department.Id }, department);
    }

    public IActionResult Display(int id)
    {
        var dept = _context.Departments
            .Include(d => d.Students)
            .FirstOrDefault(d => d.Id == id);

        if (dept == null) return NotFound();

        var vm = new DepartmentDisplayViewModel
        {
            DepartmentName = dept.Name,
            StudentsOver25 = dept.Students
                                .Where(s => s.Age > 25)
                                .Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                                {
                                    Text = s.Name,
                                    Value = s.Id.ToString()
                                })
                                .ToList(),
            DepartmentState = dept.Students.Count > 50 ? "Main" : "Branch"
        };

        return View(vm);
    }
    private IActionResult View(DepartmentDisplayViewModel vm)
    {
        throw new NotImplementedException();
    }
}