using Microsoft.AspNetCore.Mvc;
using TUTOR.Context;
using TUTOR.Model;
using Microsoft.EntityFrameworkCore;

namespace TUTOR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialTipController : ControllerBase
    {
        private readonly TutorDbContext _context;

        public HistorialTipController(TutorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllHistorial()
        {
            var historial = _context.HistorialTips
                .Include(h => h.User)
                .Include(h => h.Tip)
                .Where(h => !h.IsDeleted)
                .ToList();

            return Ok(historial);
        }

        [HttpPost]
        public IActionResult RegistrarHistorial([FromBody] HistorialTip historial)
        {
            historial.FechaVisto = DateTime.UtcNow;
            historial.Modified = DateTime.UtcNow;

            _context.HistorialTips.Add(historial);
            _context.SaveChanges();

            return Ok(historial);
        }
    }
}
