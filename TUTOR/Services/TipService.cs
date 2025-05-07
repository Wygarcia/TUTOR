using Microsoft.EntityFrameworkCore;
using TUTOR.Context;
using TUTOR.Model;

namespace TUTOR.Services
{
    public interface ITipService
    {
        Task<IEnumerable<Tip>> GetAllAsync();
        Task<Tip?> GetByIdAsync(int id);
        Task<Tip> CreateAsync(Tip tip);
        Task<bool> UpdateAsync(Tip tip);
        Task<bool> DeleteAsync(int id);
    }

    public class TipService : ITipService
    {
        private readonly TutorDbContext _context;

        public TipService(TutorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tip>> GetAllAsync()
        {
            return await _context.Tips.ToListAsync();
        }

        public async Task<Tip?> GetByIdAsync(int id)
        {
            return await _context.Tips.FindAsync(id);
        }

        public async Task<Tip> CreateAsync(Tip tip)
        {
            _context.Tips.Add(tip);
            await _context.SaveChangesAsync();
            return tip;
        }

        public async Task<bool> UpdateAsync(Tip tip)
        {
            var existing = await _context.Tips.FindAsync(tip.TipId);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(tip);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tip = await _context.Tips.FindAsync(id);
            if (tip == null) return false;

            _context.Tips.Remove(tip);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

