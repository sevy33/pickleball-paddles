using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var sql = "SELECT * FROM paddles";
            var paddles = _context.Paddles.Select(x => new
            {
                x.Id,
                x.Name,
                x.Brand
            }).ToList();      
            return Ok(paddles);
        }
    }
}
