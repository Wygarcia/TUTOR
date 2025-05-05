using Microsoft.AspNetCore.Mvc;
using TUTOR.Model;
using TUTOR.Services;

namespace TUTOR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialTipController : ControllerBase
    {
        private readonly IHistorialTipService _historialTipService;

        public HistorialTipController(IHistorialTipService historialTipService)
        {
            _historialTipService = historialTipService;
        }

        // GET: api/HistorialTip
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var historial = await _historialTipService.GetAllAsync();
            return Ok(historial);
        }

        // GET: api/HistorialTip/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var historial = await _historialTipService.GetByIdAsync(id);
            if (historial == null)
                return NotFound();
            return Ok(historial);
        }

        // POST: api/HistorialTip
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HistorialTip historialTip)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _historialTipService.AddAsync(historialTip);
            return CreatedAtAction(nameof(GetById), new { id = historialTip.HistorialTipId }, historialTip);
        }

        // PUT: api/HistorialTip/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HistorialTip historialTip)
        {
            if (id != historialTip.HistorialTipId)
                return BadRequest();

            var existing = await _historialTipService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _historialTipService.UpdateAsync(historialTip);
            return NoContent();
        }

        // DELETE: api/HistorialTip/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var historial = await _historialTipService.GetByIdAsync(id);
            if (historial == null)
                return NotFound();

            await _historialTipService.DeleteAsync(historial);
            return NoContent();
        }
    }
}
