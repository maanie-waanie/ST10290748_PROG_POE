namespace PROG_POE.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ClaimStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        // Other properties
    }

    public class ApproveClaim
    {
        public int Id { get; set; }
        public int ClaimStatusId { get; set; }
        public ClaimStatus ClaimStatus { get; set; }
        // Other properties related to approval
    }

}
//------------------------------------------------------END OF FILE----------------------------------------------------------------------------//