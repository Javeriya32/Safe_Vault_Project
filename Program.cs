using SafeVault.Data;
using SafeVault.Services;
using SafeVault.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Dependency Injection
builder.Services.AddSingleton<Database>();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// Middleware pipeline
app.UseMiddleware<SecurityHeadersMiddleware>();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
