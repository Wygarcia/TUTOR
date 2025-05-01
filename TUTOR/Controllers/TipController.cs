using Microsoft.AspNetCore.Mvc;
using TUTOR.Context;
using TUTOR.Model;

namespace TUTOR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipController : ControllerBase
    {
        private readonly TutorDbContext _context;

        public TipController(TutorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllTips()
        {
            var tips = _context.Tips.Where(t => !t.IsDeleted).ToList();
            return Ok(tips);
        }

        [HttpPost]
        public IActionResult CreateTip([FromBody] Tip tip)
        {
            tip.Modified = DateTime.UtcNow;
            _context.Tips.Add(tip);
            _context.SaveChanges();
            return Ok(tip);
        }
    }
}
