using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG_POE.Data;
using PROG_POE.Models;

//    Aman Adams
//    ST10290748
//    Prog2B POE PART 2
//    Reference: Used W3 Schools for Format and Style


namespace PROG_POE.Controllers
{
    public class ClaimController : Controller
    {
        public readonly ApplicationDbContext _context;


        public ClaimController(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //public IActionResult TrackClaimStatus(int claimId)
        //{
        //    var claimStatus = _context.claimStatus.FirstOrDefault(c => c.Id == claimId);
        //    if (claimStatus == null)
        //    {
        //        // Handle not found scenario
        //    }
        //    return View(claimStatus);
        //}

        [HttpPost]
        public async Task<IActionResult> SubmitClaims(Claim claim, IFormFile supportingDocs)
        {
            const decimal hourlyRate = 200;  // Fixed hourly rate for calculation

            if (ModelState.IsValid)
            {
                // Calculate the total amount based on the number of hours worked
                claim.claimAmount = claim.TotalHours * hourlyRate;

                if (supportingDocs != null && supportingDocs.Length > 0)
                {
                    // Save the uploaded file to wwwroot/uploads
                    var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    var fileName = Path.GetFileName(supportingDocs.FileName);  // Get the original file name

                    if (!Directory.Exists(uploadsPath))
                    {
                        Directory.CreateDirectory(uploadsPath);
                    }

                    var filePath = Path.Combine(uploadsPath, fileName);

                    // Save the file asynchronously
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await supportingDocs.CopyToAsync(stream);
                    }

                    // Store the file path in the database (relative URL)
                    claim.SupportingDocsUrl = "/uploads/" + fileName;
                }

                // Set the initial claim status to "Pending"
                claim.Status = "Pending";

                // Save the claim to the database
                _context.Claims.Add(claim);
                await _context.SaveChangesAsync();

                // Redirect to Claims Status after submitting
                return RedirectToAction("ClaimsStatus");
            }

            return View(claim);  // Return the view with validation errors if any
        }
    }

    //[HttpPost]
    //public IActionResult ApproveClaim(int claimId)
    //{
    //    var claim = _context.ApproveClaims.Include(c => c.ClaimStatus).FirstOrDefault(c => c.Id == claimId);
    //    if (claim != null)
    //    {
    //        claim.ClaimStatus.Status = "Approved"; // Update status to approved
    //        _context.SaveChanges();
    //    }
    //    return View(claim);
    //}
}
//------------------------------------------------------END OF FILE----------------------------------------------------------------------------//

