using System.Text.Json.Serialization;

namespace Server.Models
{
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
}
