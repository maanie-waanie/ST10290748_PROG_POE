





using System.Security.Claims;

namespace PROG_POE
{
    internal class Claim : System.Security.Claims.Claim
    {
        //public Claim()
        //{
        //}

        public Claim(BinaryReader reader) : base(reader)
        {
        }

        public Claim(BinaryReader reader, ClaimsIdentity? subject) : base(reader, subject)
        {
        }

        public Claim(string type, string value) : base(type, value)
        {
        }

        public Claim(string type, string value, string? valueType) : base(type, value, valueType)
        {
        }

        public Claim(string type, string value, string? valueType, string? issuer) : base(type, value, valueType, issuer)
        {
        }

        public Claim(string type, string value, string? valueType, string? issuer, string? originalIssuer) : base(type, value, valueType, issuer, originalIssuer)
        {
        }

        public Claim(string type, string value, string? valueType, string? issuer, string? originalIssuer, ClaimsIdentity? subject) : base(type, value, valueType, issuer, originalIssuer, subject)
        {
        }

        protected Claim(System.Security.Claims.Claim other) : base(other)
        {
        }

        protected Claim(System.Security.Claims.Claim other, ClaimsIdentity? subject) : base(other, subject)
        {
        }

        public int claimAmount { get; set; }
        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }
        public string LecturerName { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
// -----------------------------------------END OF FILE----------------------------------------------------------------------------//