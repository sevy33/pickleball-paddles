using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
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
}
