using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly PaddleContext _context;

        public ReviewsController(PaddleContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<PaddleReview>> PostReview(PaddleReview review)
        {
            review.CreatedAt = DateTime.UtcNow;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return Created($"/api/paddles/{review.PaddleId}", review);
        }
    }
}
