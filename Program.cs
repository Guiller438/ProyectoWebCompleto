using IW7PP.Controllers.ComponentsControllers;
using IW7PP.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<FeetController>();
builder.Services.AddScoped<ProsthesisController>();
builder.Services.AddScoped<KneeArticulateController>();
builder.Services.AddScoped<LinerController>();
builder.Services.AddScoped<SocketController>();
builder.Services.AddScoped<TubesController>();
builder.Services.AddScoped<UnionSocketsController>();



builder.Services.AddDbContext<ApplicationDbContext>(opciones =>

    opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Users/Login";

});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
