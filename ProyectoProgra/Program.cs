using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProyectoProgra.Models;
using ProyectoProgra.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var connectionString = builder.Configuration.GetConnectionString("PFContext");
builder.Services.AddDbContext<PFContext>(x => x.UseSqlServer(connectionString));

var connectionString2 = builder.Configuration.GetConnectionString("LoginContext");
builder.Services.AddDbContext<LoginContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LoginContext>();

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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints => {
    endpoints.MapRazorPages();
});

app.Run();
