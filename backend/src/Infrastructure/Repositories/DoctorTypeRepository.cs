using Core.Entities;
using Core.Interfaces;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DoctorTypeRepository : IDoctorTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorType>> GetAllAsync()
        {
            return await _context.DoctorTypes.ToListAsync();
        }

        public async Task<DoctorType?> GetByIdAsync(int id)
        {
            return await _context.DoctorTypes.FindAsync(id);
        }

        public async Task<DoctorType> AddAsync(DoctorType entity)
        {
            _context.DoctorTypes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(DoctorType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.DoctorTypes.FindAsync(id);
            if (entity != null)
            {
                _context.DoctorTypes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DoctorType?> GetByColorAsync(string color)
        {
            return await _context.DoctorTypes.FindAsync(color);
        }
    }
}