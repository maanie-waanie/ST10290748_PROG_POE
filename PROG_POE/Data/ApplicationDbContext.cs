
using Microsoft.EntityFrameworkCore;
using PROG_POE.Models;
using System.Collections.Generic;


namespace PROG_POE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Claim> Claims { get; set; }
        //public DbSet<ClaimStatusModel> ClaimStatuses { get; set; }
        // public DbSet<ApproveClaimModel> ApproveClaims { get; set; }

        // Add other DbSets for each table in your database
    }
}
