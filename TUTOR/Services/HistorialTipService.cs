using Microsoft.EntityFrameworkCore;
using TUTOR.Context;
using TUTOR.Model;

namespace TUTOR.Services
{
    public interface IHistorialTipService
    {
        Task<IEnumerable<HistorialTip>> GetAllAsync();
        Task<HistorialTip?> GetByIdAsync(int id);
        Task<HistorialTip> CreateAsync(HistorialTip historial);
        Task<bool> DeleteAsync(int id);
    }

    public class HistorialTipService : IHistorialTipService
    {
        private readonly TutorDbContext _context;

        public HistorialTipService(TutorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistorialTip>> GetAllAsync()
        {
            return await _context.HistorialTips
                .Include(h => h.User)
                .Include(h => h.Tip)
                .ToListAsync();
        }

        public async Task<HistorialTip?> GetByIdAsync(int id)
        {
            return await _context.HistorialTips
                .Include(h => h.User)
                .Include(h => h.Tip)
                .FirstOrDefaultAsync(h => h.HistorialTipId == id);
        }

        public async Task<HistorialTip> CreateAsync(HistorialTip historial)
        {
            _context.HistorialTips.Add(historial);
            await _context.SaveChangesAsync();
            return historial;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var historial = await _context.HistorialTips.FindAsync(id);
            if (historial == null) return false;

            _context.HistorialTips.Remove(historial);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
