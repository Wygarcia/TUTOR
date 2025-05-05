using Microsoft.AspNetCore.Mvc;
using TUTOR.Model;
using TUTOR.Services;

namespace TUTOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialTipController : ControllerBase
    {
        private readonly IHistorialTipService _historialTipService;

        public HistorialTipController(IHistorialTipService historialTipService)
        {
            _historialTipService = historialTipService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialTip>>> GetAllAsync()
        {
            var historialTips = await _historialTipService.GetAllAsync();
            return Ok(historialTips);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialTip>> GetByIdAsync(int id)
        {
            var historialTip = await _historialTipService.GetByIdAsync(id);
            if (historialTip == null)
            {
                return NotFound();
            }
            return Ok(historialTip);
        }

        [HttpPost]
        public async Task<ActionResult<HistorialTip>> AddAsync(HistorialTip historialTip)
        {
            await _historialTipService.AddAsync(historialTip);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = historialTip.HistorialTipId }, historialTip);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, HistorialTip historialTip)
        {
            // Verificar si el id de la URL coincide con el id del objeto
            if (id != historialTip.HistorialTipId)
            {
                return BadRequest("El id de la URL no coincide con el id del objeto.");
            }

            try
            {
                await _historialTipService.UpdateAsync(historialTip);
                return NoContent(); // Devuelve un 204 No Content si la actualización fue exitosa
            }
            catch (KeyNotFoundException)
            {
                return NotFound("El historial tip no fue encontrado.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var historialTip = await _historialTipService.GetByIdAsync(id);
            if (historialTip == null)
            {
                return NotFound();
            }

            await _historialTipService.DeleteAsync(historialTip);
            return NoContent(); // Devuelve un 204 No Content si la eliminación fue exitosa
        }
    }
}
