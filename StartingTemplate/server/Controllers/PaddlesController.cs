using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaddlesController : ControllerBase
    {   
        private readonly PaddleContext _context;
        public PaddlesController(PaddleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPaddles()
        {
            var paddles = _context.Paddles.Include(x => x.Images).ToList();
            var paddleDtos = paddles.Select(p => new PaddleDto
            {
                Id = p.Id,
                Name = p.Name,
                Brand = p.Brand,
                Price = p.Price,
                ThumbnailUrl = p.Images != null && p.Images.Count > 0 ? p.Images.First().ImageUrl : null
            }).ToList();      
            return Ok(paddleDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaddle(int id)
        {
            var paddle = _context.Paddles.Include(x => x.Images).FirstOrDefault(p => p.Id == id);
            if (paddle == null)
            {
                return NotFound();
            }

            var paddleDto = new PaddleDto
            {
                Id = paddle.Id,
                Name = paddle.Name,
                Brand = paddle.Brand,
                Price = paddle.Price,
                ThumbnailUrl = paddle.Images != null && paddle.Images.Count > 0 ? paddle.Images.First().ImageUrl : null
            };

            return Ok(paddleDto);
        }
    }

    public class PaddleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ThumbnailUrl { get; set; }
        public decimal Price { get; set; }
    }
}
