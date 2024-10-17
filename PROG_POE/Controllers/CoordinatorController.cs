using Microsoft.AspNetCore.Mvc;

namespace PROG_POE.Controllers
{
    public class CoordinatorController : Controller
    {
        public IActionResult CoordinatorDashboard()
        {
            return View();
        }
    }
}
