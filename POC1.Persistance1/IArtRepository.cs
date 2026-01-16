using POC1.Entities1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC1.Persistance1
{
    public interface IArtRepository
    {
        
        Task<IEnumerable<Art>> GetAllAsync(); // READ all
        Task<Art?> GetByIdAsync(int id);      // READ one

        Task<Art> AddAsync(Art entity);       // CREATE
        Task<Art?> UpdateAsync(Art entity);   // UPDATE
        Task<bool> DeleteAsync(int id);       // DELETE
    }
}
