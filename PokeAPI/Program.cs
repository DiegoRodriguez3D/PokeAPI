// Program.cs
using PokeApi.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// 1) Configurar NLog:
builder.Logging.ClearProviders();
builder.Host.UseNLog(); // NLog se encargar� del logging ahora.

// 2) Agregar EF Core con SQLServer:
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3) Configurar Identity:
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// 4) Configurar autenticaci�n JWT (luego a�adiremos los detalles):
// builder.Services.AddAuthentication(options => { ... })
//     .AddJwtBearer(...)

// 5) Agregar controladores + versionado + etc.
builder.Services.AddControllers();

// 6) Construir la app
var app = builder.Build();

app.UseHttpsRedirection();

// app.UseAuthentication(); // Luego lo habilitamos cuando la configuraci�n JWT est� lista
// app.UseAuthorization();

app.MapControllers();

app.Run();
