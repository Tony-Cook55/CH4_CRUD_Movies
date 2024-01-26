

using Microsoft.EntityFrameworkCore;
using MovieProject.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();







// ADDING EF core Dependency Injection
// Allows us to work with or movie context files to query the data
builder.Services.AddDbContext<MovieContextModel>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoiveContext")));


// Makes everything in the url lowercase and adds a / to the end of the url
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});








var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",                                // ADD slug to allow for 
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
