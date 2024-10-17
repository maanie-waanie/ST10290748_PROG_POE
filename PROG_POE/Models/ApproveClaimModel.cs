using System.ComponentModel.DataAnnotations;


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
