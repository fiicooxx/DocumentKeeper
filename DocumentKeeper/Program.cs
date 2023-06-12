using Infrastructure.Repositories;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Data;
using Web;
using ApplicationCore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var serviceProvider = builder.Services.BuildServiceProvider();
var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

// Role
string[] roles = { "Administrator", "U¿ytkownik" };

foreach (var role in roles)
{
    if (!await roleManager.RoleExistsAsync(role))
        await roleManager.CreateAsync(new IdentityRole(role));
}

// Dodanie nowego u¿ytkownika
var user = new IdentityUser { UserName = "UserName", Email = "user@example.com" };
var result = await userManager.CreateAsync(user, "Has³o");

if (result.Succeeded)
{
    await userManager.AddToRoleAsync(user, "NazwaRoli");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();

app.Run();
