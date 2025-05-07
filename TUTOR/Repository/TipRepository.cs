using Microsoft.EntityFrameworkCore;
using TUTOR.Context;
using TUTOR.Model;

namespace TUTOR.Repository
{
    public interface ITipRepository
    {
        Task<IEnumerable<Tip>> GetAllAsync();
        Task<Tip?> GetByIdAsync(int id);
        Task AddAsync(Tip tip);
        Task UpdateAsync(Tip tip);
        Task DeleteAsync(Tip tip);
    }

    public class TipRepository : ITipRepository
    {
        private readonly TutorDbContext _context;

        public TipRepository(TutorDbContext context)
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

        public async Task AddAsync(Tip tip)
        {
            _context.Tips.Add(tip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tip tip)
        {
            _context.Tips.Update(tip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tip tip)
        {
            _context.Tips.Remove(tip);
            await _context.SaveChangesAsync();
        }
    }
}
