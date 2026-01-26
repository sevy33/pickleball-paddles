using System;
using Microsoft.EntityFrameworkCore;

namespace server.Data;

public class PaddleContext : DbContext
{
    public PaddleContext(DbContextOptions<PaddleContext> options) : base(options)
    {
    }

    public DbSet<Domain.Paddle> Paddles { get; set; }
}
