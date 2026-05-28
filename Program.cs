using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using BackEP26.Data;
using BackEP26.Hubs;
using BackEP26.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddScoped<GoogleTokenService>();
builder.Services.AddHttpClient<RecaptchaService>();

// Rate limiting: solo se aplica al endpoint de voto con [EnableRateLimiting("vote")]
builder.Services.AddRateLimiter(opt =>
{
    opt.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    opt.AddFixedWindowLimiter("vote", o =>
    {
        o.PermitLimit = 3;
        o.Window = TimeSpan.FromMinutes(1);
        o.QueueLimit = 0;
        o.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});

// CORS
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()
    ?? ["http://localhost:5173"];
builder.Services.AddCors(opt =>
    opt.AddDefaultPolicy(p => p
        .WithOrigins(allowedOrigins)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()));

builder.Services.AddSignalR();
builder.Services.AddControllers();

var app = builder.Build();

// Aplicar migraciones automáticamente al iniciar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Orden correcto: CORS antes de rate limiting
app.UseCors();
app.UseRateLimiter();
app.MapControllers();
app.MapHub<ResultsHub>("/hubs/results");
app.Run();
