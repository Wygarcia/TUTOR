using Microsoft.EntityFrameworkCore;
using TUTOR.Context;
using TUTOR.Model;

namespace TUTOR.Repository
{
    public interface IHistorialTipRepository
    {
        Task<IEnumerable<HistorialTip>> GetAllAsync();
        Task<HistorialTip?> GetByIdAsync(int id);
        Task AddAsync(HistorialTip historialTip);
        Task UpdateAsync(HistorialTip historialTip);
        Task DeleteAsync(HistorialTip historialTip);
    }

    public class HistorialTipRepository : IHistorialTipRepository
    {
        private readonly TutorDbContext _context;

        public HistorialTipRepository(TutorDbContext context)
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

        public async Task AddAsync(HistorialTip historialTip)
        {
            _context.HistorialTips.Add(historialTip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HistorialTip historialTip)
        {
            _context.HistorialTips.Update(historialTip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(HistorialTip historialTip)
        {
            _context.HistorialTips.Remove(historialTip);
            await _context.SaveChangesAsync();
        }
    }
}
