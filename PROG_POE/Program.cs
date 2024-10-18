using Microsoft.EntityFrameworkCore;
using PROG_POE.Data;


//    Aman Adams
//    ST10290748
//    Prog2B POE PART 2
//    Reference: Used W3 Schools for Format and Style

var builder = WebApplication.CreateBuilder(args);


//Add services to the container.
builder.Services.AddControllersWithViews();

//Register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //The default HSTS value is 30 days. 
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//Configure the HTTP request pipeline...


app.Run();
//------------------------------------------------------END OF FILE----------------------------------------------------------------------------//