using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PROG_POE.Data;
using PROG_POE.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PROG_POE.Views.Home
{
    public class HRDashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public HRDashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Claim> ApprovedClaims { get; set; }
        public List<Claim> Lecturers { get; set; }
        [BindProperty]
        public Claim SelectedLecturer { get; set; }

        public async Task OnGetAsync()
        {
            // Load approved claims
            ApprovedClaims = await _context.Claims
                .Where(c => c.Status == "Approved")
                .ToListAsync();

            // Load lecturers
            Lecturers = await _context.Claims.ToListAsync();
        }

        public async Task<IActionResult> OnPostUpdateLecturerAsync(string LecturerId, string ContactNumber, string EmailAddress)
        {
            // Update lecturer data
            var lecturer = await _context.Claims.FindAsync(LecturerId);
            if (lecturer != null)
            {
                lecturer.ContactNumber = ContactNumber;
                lecturer.Email = EmailAddress;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostGenerateReport()
        {
            // Generate a simple CSV report for approved claims
            var csv = "ClaimId, LecturerName, HoursWorked, TotalAmount, ApprovedDate\n" +
                      string.Join("\n", ApprovedClaims.Select(c => $"{c.ClaimID}, {c.LecturerName}, {c.TotalHours}, {c.claimAmount}, {c.ApprovedDate}"));

            return File(System.Text.Encoding.UTF8.GetBytes(csv), "text/csv", "ApprovedClaimsReport.csv");
        }
    }
}

