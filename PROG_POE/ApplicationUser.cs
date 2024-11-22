using Microsoft.AspNetCore.Identity;

namespace PROG_POE
{
    public class ApplicationUser : IdentityUser
    {
        // Custom properties for the user
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleDescription { get; set; }
    }
}

//---------------------------------------------------------------------------------------END OF FILE-----------------------------------------------------------------------------------------------------// 