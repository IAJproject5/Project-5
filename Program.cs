using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project_5.Areas.Identity.Data;
using Project_5.Data;
using Project_5.Helpers;
using Project_5.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Project_5ContextConnection") ?? throw new InvalidOperationException("Connection string 'Project_5ContextConnection' not found.");

builder.Services.AddDbContext<Project_5Context>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion (new Version(10,4,27))));
builder.Services.AddDbContext<Project5Context>(options =>
	options.UseMySql(connectionString, new MySqlServerVersion (new Version(10,4,27))));

builder.Services.AddDefaultIdentity<Project_5User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<Project_5Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UserManagementHelper>();
builder.Services.AddScoped<PlanHelper>();
builder.Services.AddScoped<FacultyHelper>();

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
app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
    app.UseDeveloperExceptionPage();
    }

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
    endpoints.MapControllerRoute(
	    name: "default",
	    pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}
public interface IConfiguration { }
