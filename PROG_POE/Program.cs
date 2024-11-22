using Microsoft.EntityFrameworkCore;
using PROG_POE.Data;
using Microsoft.AspNetCore.Identity;
using PROG_POE;
using Microsoft.Extensions.DependencyInjection;


////    Aman Adams
////    ST10290748
////    Prog2B POE PART 3
////    Reference: Used W3 Schools for Format and Style


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Identity services
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add authentication
builder.Services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

// Add authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Seed roles and users
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    await DatabaseSeeder.SeedRolesAndUsers(services);
//}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
//------------------------------------------------------END OF FILE----------------------------------------------------------------------------//


//var builder = WebApplication.CreateBuilder(args);


////Add services to the container.
//builder.Services.AddControllersWithViews();

////Register ApplicationDbContext
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//var app = builder.Build();


////Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    //The default HSTS value is 30 days. 
//    app.UseHsts();
//}
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Add Identity services
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    //.AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

//// Add authentication and authorization
//builder.Services.AddAuthentication()
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Account/Login"; // Set the login page URL
//        options.LogoutPath = "/Account/Logout"; // Set the logout page URL
//    });

//// Register the necessary services
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Lecturer", policy => policy.RequireRole("Lecturer"));
//    options.AddPolicy("Coordinator", policy => policy.RequireRole("Coordinator"));
//    options.AddPolicy("HR", policy => policy.RequireRole("HR"));
//});
//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");


////Configure the HTTP request pipeline...


//app.Run();


//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();
//// Add services to the container.

//var mvcBuilder = builder.Services.AddControllersWithViews();

//// Register ApplicationDbContext




//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//// Add authentication middleware
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();

////------------------------------------------------------END OF FILE----------------------------------------------------------------------------//