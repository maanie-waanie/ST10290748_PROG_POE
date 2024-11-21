using Microsoft.AspNetCore.Mvc;
using PROG_POE.Data;
using PROG_POE.Models;

namespace PROG_POE.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Submit claim
        [HttpPost]
        public async Task<IActionResult> SubmitClaim(Claim claim, IFormFile supportingDocuments)
        {
            if (ModelState.IsValid)
            {
                // Save the claim data to the database
                _context.Claims.Add(claim);
                await _context.SaveChangesAsync();

                // Save the supporting document (if any)
                if (supportingDocuments != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/SupportingDocuments", supportingDocuments.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await supportingDocuments.CopyToAsync(stream);
                    }
                }

                return RedirectToAction("LecturerDashboard");
            }

            return View(claim);
        }
    }

}
