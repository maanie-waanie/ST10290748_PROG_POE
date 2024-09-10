using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc;

/// Summary 
/// Aman Adams
/// ST10290748
/// PROG2B PART 1
/// Summary


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
