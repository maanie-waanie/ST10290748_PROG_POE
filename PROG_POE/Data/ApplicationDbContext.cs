using Microsoft.EntityFrameworkCore;
using PROG_POE.Models;
using System.Collections.Generic;


//    Aman Adams
//    ST10290748
//    Prog2B POE PART 2
//    Reference: Used W3 Schools for Format and Style


namespace PROG_POE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Claim> Claims { get; set; }

    }
}
//------------------------------------------------------END OF FILE----------------------------------------------------------------------------//