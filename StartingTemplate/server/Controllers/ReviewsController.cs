using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly PaddleContext _context;

        public ReviewsController(PaddleContext context)
        {
            _context = context;
        }

        [HttpGet("{paddleId}")]
        public async Task<IActionResult> GetReviews(string paddleId)
        {
            var reviews = await _context.Reviews.Where(r => r.PaddleId == paddleId).ToListAsync();
            return Ok(reviews);
        }
    }
}
