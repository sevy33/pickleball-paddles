using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Domain;

public class Review
{
    [Key]
    public int Id { get; set; }
    public string PaddleId { get; set; }
    public string ReviewerName { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}
