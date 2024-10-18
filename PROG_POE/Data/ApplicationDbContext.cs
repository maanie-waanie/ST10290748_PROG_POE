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

    }
}
