using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PaddleContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Avoid circular references in JSON serialization
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


var app = builder.Build();

app.UseCors("AllowAll");

// API Endpoints

// GET /api/paddles - Search and Filter
app.MapGet("/api/paddles", async (PaddleContext db, string? search, decimal? minPrice, decimal? maxPrice) =>
{
    var query = db.Paddles.Include(p => p.Images).AsQueryable();

    if (!string.IsNullOrWhiteSpace(search))
    {
        var term = search.ToLower();
        query = query.Where(p => p.Name.ToLower().Contains(term) || p.Brand.ToLower().Contains(term));
    }

    if (minPrice.HasValue)
        query = query.Where(p => p.Price >= minPrice.Value);

    if (maxPrice.HasValue)
        query = query.Where(p => p.Price <= maxPrice.Value);

    return await query.ToListAsync();
});

// GET /api/paddles/{id} - Details with Images and Reviews
app.MapGet("/api/paddles/{id}", async (int id, PaddleContext db) =>
{
    var paddle = await db.Paddles
        .Include(p => p.Images)
        .Include(p => p.Reviews)
        .FirstOrDefaultAsync(p => p.Id == id);

    return paddle is not null ? Results.Ok(paddle) : Results.NotFound();
});

// POST /api/reviews - Add Review
app.MapPost("/api/reviews", async (PaddleReview review, PaddleContext db) =>
{
    review.CreatedAt = DateTime.UtcNow;
    db.Reviews.Add(review);
    await db.SaveChangesAsync();
    return Results.Created($"/api/paddles/{review.PaddleId}", review);
});

app.Run();

// Data Models
public class Paddle
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    [JsonPropertyName("surface_material")]
    public string? SurfaceMaterial { get; set; }
    [JsonPropertyName("core_material")]
    public string? CoreMaterial { get; set; }
    [JsonPropertyName("weight_oz")]
    public decimal? WeightOz { get; set; }
    [JsonPropertyName("is_approved")]
    public bool IsApproved { get; set; }

    public List<PaddleImage> Images { get; set; } = new();
    public List<PaddleReview> Reviews { get; set; } = new();
}

public class PaddleImage
{
    public int Id { get; set; }
    public int PaddleId { get; set; }
    [JsonIgnore]
    public Paddle? Paddle { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsPrimary { get; set; }
}

public class PaddleReview
{
    public int Id { get; set; }
    public int PaddleId { get; set; }
    [JsonIgnore]
    public Paddle? Paddle { get; set; }
    public string ReviewerName { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string? Comment { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}

// DbContext
public class PaddleContext : DbContext
{
    public PaddleContext(DbContextOptions<PaddleContext> options) : base(options) { }

    public DbSet<Paddle> Paddles => Set<Paddle>();
    public DbSet<PaddleImage> Images => Set<PaddleImage>();
    public DbSet<PaddleReview> Reviews => Set<PaddleReview>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paddle>(entity =>
        {
            entity.ToTable("paddles");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Brand).HasColumnName("brand");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.SurfaceMaterial).HasColumnName("surface_material");
            entity.Property(e => e.CoreMaterial).HasColumnName("core_material");
            entity.Property(e => e.WeightOz).HasColumnName("weight_oz");
            entity.Property(e => e.IsApproved).HasColumnName("is_approved");
        });

        modelBuilder.Entity<PaddleImage>(entity =>
        {
            entity.ToTable("paddle_images");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PaddleId).HasColumnName("paddle_id");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.IsPrimary).HasColumnName("is_primary");
        });

        modelBuilder.Entity<PaddleReview>(entity =>
        {
            entity.ToTable("paddle_reviews");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PaddleId).HasColumnName("paddle_id");
            entity.Property(e => e.ReviewerName).HasColumnName("reviewer_name");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
        });
    }
}
