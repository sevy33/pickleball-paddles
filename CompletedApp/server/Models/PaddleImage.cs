using System.Text.Json.Serialization;

namespace Server.Models
{
    public class PaddleImage
    {
        public int Id { get; set; }
        public int PaddleId { get; set; }
        [JsonIgnore]
        public Paddle? Paddle { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
    }
}
