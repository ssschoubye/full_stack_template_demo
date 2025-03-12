using Core.Entities;
using Core.Interfaces;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShiftTypeRepository : IShiftTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ShiftTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShiftType>> GetAllAsync()
        {
            return await _context.ShiftTypes.ToListAsync();
        }

        public async Task<ShiftType?> GetByIdAsync(int id)
        {
            return await _context.ShiftTypes.FindAsync(id);
        }

        public async Task<ShiftType> AddAsync(ShiftType entity)
        {
            _context.ShiftTypes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ShiftType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.ShiftTypes.FindAsync(id);
            if (entity != null)
            {
                _context.ShiftTypes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ShiftType?> GetByColorAsync(string color)
        {
            return await _context.ShiftTypes.FindAsync(color);
        }
    }
}