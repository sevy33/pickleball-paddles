using System.Text.Json.Serialization;

namespace Server.Models
{
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
}
