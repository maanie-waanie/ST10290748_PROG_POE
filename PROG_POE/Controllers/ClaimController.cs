using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc;

namespace PROG_POE.Controllers
{
    public class ClaimController : Controller
    {
        public IActionResult SubmitClaim()
        {
            return View();
        }

        public IActionResult TrackClaimStatus()
        {
            return View();
        }

        public IActionResult UploadDocuments()
        {
            return View();
        }

        public IActionResult ApproveClaim()
        {
            return View();
        }
    }
}
