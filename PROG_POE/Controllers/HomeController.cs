using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG_POE.Data;
using PROG_POE.Models;
using System.Diagnostics;

//    Aman Adams
//    ST10290748
//    Prog2B POE PART 3
//    Reference: Used W3 Schools for Format and Style


namespace PROG_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

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

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ApproveClaim()
        {
            return View();
        }

      
        //public async Task<IActionResult> ApproveClaim(int claimId)
        //{
        //    var claim = await _context.Claims.FindAsync(claimId);
        //    if (claim == null)
        //    {
        //        return NotFound();
        //    }

        //    // Implement validation logic (e.g., ensuring claim is within allowable limits)
        //    if (claim.TotalHours >= 0 && claim.HourlyRate > 0)
        //    {
        //        claim.Status = "Approved";
        //    }
        //    else
        //    {
        //        claim.Status = "Rejected";
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("CoordinatorDashboard");
        //}


        //public IActionResult ApproveClaim()
        //{
        //    var claims = _context.Claims.Where(c => c.Status == "Submitted").ToList();
        //    if (claims == null)
        //    {
        //        claims = new List<Claim>();
        //    }

        //    return View(claims);
        //}

        //public async Task<IActionResult> ApproveClaim(int claimId, string action)
        //{
        //    var claim = await _context.Claims.FindAsync(claimId);
        //    if (claim == null)
        //    {
        //        return NotFound();
        //    }

        //    // Handle approval or rejection
        //    if (action == "approve")
        //    {
        //        claim.Status = "Approved";
        //    }
        //    else if (action == "reject")
        //    {
        //        claim.Status = "Rejected";
        //    }

        //    // Save the updated claim status
        //    _context.Update(claim);
        //    await _context.SaveChangesAsync();

        //    // Redirect to the list of claims
        //    return RedirectToAction(nameof(ApproveClaim)); // Assuming you want to reload the claims page
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

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
}

//------------------------------------------------------END OF FILE----------------------------------------------------------------------------//