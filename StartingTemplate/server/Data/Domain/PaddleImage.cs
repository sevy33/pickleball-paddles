using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Domain;
[Table("paddle_images")] // Mapping database to ORM
public class PaddleImage
{
    [Key]
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public int PaddleId { get; set; }
    public Paddle Paddle { get; set; }

}
