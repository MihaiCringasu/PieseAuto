using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PieseAuto.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PieseAutoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PieseAutoContext") ?? throw new InvalidOperationException("Connection string 'PieseAutoContext' not found.")));

// Configurarea contextului pentru Identity
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PieseAutoContext") ?? throw new InvalidOperationException("Connection string 'PieseAutoContext' not found.")));

// Configurarea Identity pentru autentificare
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; 
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 1;
})
    .AddEntityFrameworkStores<LibraryIdentityContext>()
    .AddDefaultTokenProviders();

// Configurarea cookie-urilor pentru autentificare
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // SeteazA pagina de login
    options.LogoutPath = "/Account/Logout"; 
    options.AccessDeniedPath = "/Account/AccessDenied"; 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapRazorPages();

app.Run();
