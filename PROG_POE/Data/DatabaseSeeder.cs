using Microsoft.AspNetCore.Identity;

//    Aman Adams
//    ST10290748
//    Prog2B POE PART 3
//    Reference: Used W3 Schools for Format and Style
namespace PROG_POE.Data
{
    public class DatabaseSeeder
    {
        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            // Get required services
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Define roles
            string[] roles = { "Lecturer", "Coordinator", "HR" };

            // Create roles if they don't exist
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create Lecturer user
            var lecturerUser = new ApplicationUser
            {
                UserName = "lecturer@poe.com",
                Email = "lecturer@poe.com"
            };

            if (userManager.Users.All(u => u.UserName != lecturerUser.UserName))
            {
                var result = await userManager.CreateAsync(lecturerUser, "Lecturer@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(lecturerUser, "Lecturer");
                }
            }

            // Create Coordinator user
            var coordinatorUser = new ApplicationUser
            {
                UserName = "coordinator@poe.com",
                Email = "coordinator@poe.com"
            };

            if (userManager.Users.All(u => u.UserName != coordinatorUser.UserName))
            {
                var result = await userManager.CreateAsync(coordinatorUser, "Coordinator@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(coordinatorUser, "Coordinator");
                }
            }

            // Create HR user
            var hrUser = new ApplicationUser
            {
                UserName = "hr@poe.com",
                Email = "hr@poe.com"
            };

            if (userManager.Users.All(u => u.UserName != hrUser.UserName))
            {
                var result = await userManager.CreateAsync(hrUser, "HR@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(hrUser, "HR");
                }
            }
        }
    }
}

