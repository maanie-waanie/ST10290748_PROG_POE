using System.ComponentModel.DataAnnotations;

//    Aman Adams
//    ST10290748
//    Prog2B POE PART 3
//    Reference: Used W3 Schools for Format and Style


namespace PROG_POE.Models
{
    public class ApproveClaimModel
    {
        public int Id { get; set; }
        public string ApproverName { get; set; }
        public DateTime ApprovalDate { get; set; }
        public object ClaimStatus { get; internal set; }
    }
}
//------------------------------------------------------END OF FILE----------------------------------------------------------------------------//