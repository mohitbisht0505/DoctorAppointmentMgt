using DoctorAppointmentMgt.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connectrionString="Data Source=DESKTOP-FA5HHDK; initial catalog=DoctorBookDB; integrated security=True; TrustServerCertificate=True";
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectrionString));

builder.Services.AddDistributedMemoryCache();
// to enable session
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "DoctorAppointmentSession";
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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
//session use
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Doctor}/{action=PatientDoctor}/{id?}");

app.Run();
