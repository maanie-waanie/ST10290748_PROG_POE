using Microsoft.AspNetCore.Mvc;

namespace PROG_POE.Controllers
{
    public class HRController : Controller
    {
        public IActionResult HRDashboard()
        {
            return View();
        }
    }
}
