using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Domain;

[Table("paddles")]
public class Paddle
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string SurfaceMaterial { get; set; }
    public string CoreMaterial { get; set; }
    public decimal WeightOz { get; set; }
    public bool IsApproved { get; set; }
}
