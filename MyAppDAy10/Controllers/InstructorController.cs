using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
    public class InstructorController : Controller
    {
        // Authenticated Users only
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        // Admin only
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly()
        {
            return View();
        }
    }
}