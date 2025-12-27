using Microsoft.EntityFrameworkCore;
using POC1.Entities1;

namespace POC1.Persistance1
{
    public class ArtRepository : IArtRepository
    {
        private readonly ApplicationDbContext _context;

        public ArtRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Art>> GetAllAsync()
        {
            return await _context.Arts.AsNoTracking().ToListAsync();
        }

        // READ: get one
        public async Task<Art?> GetByIdAsync(int id)
        {
            return await _context.Arts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        // CREATE: add new
        public async Task<Art> AddAsync(Art entity)
        {
            await _context.Arts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity; // Id is filled now
        }

        // UPDATE: modify existing
        public async Task<Art?> UpdateAsync(Art entity)
        {
            var existing = await _context.Arts.FindAsync(entity.Id);
            if (existing == null)
                return null;

            existing.Name = entity.Name;
            existing.Age = entity.Age;
            // copy other properties too

            await _context.SaveChangesAsync();
            return existing;
        }

        // DELETE: by id
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Arts.FindAsync(id);
            if (existing == null)
                return false;

            _context.Arts.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
   

