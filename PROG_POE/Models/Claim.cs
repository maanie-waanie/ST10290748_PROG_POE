using System.ComponentModel.DataAnnotations;

namespace PROG_POE.Models
{
    public class Claim
    {
        [Key]
        public int ClaimID { get; set; }

        [Required]
        public string LecturerName { get; set; }

        [Range(0, double.MaxValue)]
        public decimal claimAmount { get; set; }  // This field represents the calculated total claim amount

        [Range(0, 100)]
        public int TotalHours { get; set; }  // Renamed from hoursWorked to TotalHours for clarity

        [Display(Name = "Supporting Documents")]
        public string SupportingDocsUrl { get; set; }  // URL to the uploaded document

        public string Status { get; set; }  // Pending, Approved, etc.

        public string AdditionalNotes { get; set; }  // Optional field for additional notes

    }
}
