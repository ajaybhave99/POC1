
using POC1;
using POC1.coreAPI.Delegates;
using POC1.Entities1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace POC1.coreAPI.Services
{
    public interface IArtServices
    {
        Task<IEnumerable<Art>> GetAllAsync();
        Task<Art?> GetByIdAsync(int id);
        Task<Art> CreateAsync(Art art);
        Task<Art?> UpdateAsync(Art art);
        Task<bool> DeleteAsync(int id);
    }
}
