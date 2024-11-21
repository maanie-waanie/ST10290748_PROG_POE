using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG_POE.Data;

namespace PROG_POE.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoordinatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Dashboard to view submitted claims
        public async Task<IActionResult> CoordinatorDashboard()
        {
            var claims = await _context.Claims.Where(c => c.Status == "Submitted").ToListAsync();
            return View(claims);
        }

        // Approve claim
        [HttpPost]
        public async Task<IActionResult> ApproveClaim(int claimId)
        {
            var claim = await _context.Claims.FindAsync(claimId);
            if (claim == null)
            {
                return NotFound();
            }

            // Assuming simple approval logic: Check if hours worked are within expected range, etc.
            if (claim.TotalHours >= 0 && claim.HourlyRate >= 0)
            {
                claim.Status = "Approved";
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("CoordinatorDashboard");
        }
    }

}
