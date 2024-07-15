using IW7PP.Controllers;
using IW7PP.Controllers.Cliente;
using IW7PP.Controllers.ComponentsControllers;
using IW7PP.Controllers.Donations;
using IW7PP.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

// Registrar controladores espec�ficos como servicios
builder.Services.AddScoped<FeetController>();
builder.Services.AddScoped<ProsthesisController>();
builder.Services.AddScoped<KneeArticulateController>();
builder.Services.AddScoped<LinerController>();
builder.Services.AddScoped<SocketController>();
builder.Services.AddScoped<TubesController>();
builder.Services.AddScoped<UnionSocketsController>();
builder.Services.AddScoped<ClienteController>();
builder.Services.AddScoped<LifeStyleController>();
builder.Services.AddScoped<DonationsController>();


// Configuraci�n de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configuraci�n de cookies de autenticaci�n
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Users/Login";
});


// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder
            .WithOrigins("http://localhost:3000") // URL de tu aplicaci�n React
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configuraci�n del pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowReactApp");

app.UseAuthentication(); 
app.UseAuthorization();



app.MapControllerRoute(
    name: "admin",
    pattern: "{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "protesista",
    pattern: "{controller=Protesista}/{action=Index}/{id?}");

app.MapFallbackToFile("/index.html"); // Asegura que las rutas no manejadas por el servidor se sirvan desde React


app.Run();
