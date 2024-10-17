using Microsoft.AspNetCore.Mvc;

namespace PROG_POE.Controllers
{
    public class LecturerController : Controller
    {
        public IActionResult LecturerDashboard()
        {
            return View();
        }
    }
}
