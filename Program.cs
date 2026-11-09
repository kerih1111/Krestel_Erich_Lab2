using Microsoft.EntityFrameworkCore;using Krestel_Erich_Lab2.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    policy.RequireRole("Admin"));
});

var connectionString = builder.Configuration.GetConnectionString("Krestel_Erich_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Krestel_Erich_Lab2Context' not found.");

builder.Services.AddDbContext<LibraryIdentityContext>(options =>


options.UseSqlServer(builder.Configuration.GetConnectionString("Krestel_Erich_Lab2Context") ?? throw new InvalidOperationException(
    "Connection string 'Krestel_Erich_Lab2Context' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

builder.Services.AddDbContext<Krestel_Erich_Lab2Context>(options => options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddRazorPages(options => 
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/MemberPages", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Publishers", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/CategoryPages", "AdminPolicy");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
