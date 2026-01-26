using Microsoft.EntityFrameworkCore;
using server.Data;
using System.Text.Json.Serialization;
// using Server.Data; // Uncomment when Data folder is populated

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext (Uncomment when PaddleContext is created)
builder.Services.AddDbContext<PaddleContext>(options =>
   options.UseNpgsql(connectionString)
          .UseSnakeCaseNamingConvention());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
