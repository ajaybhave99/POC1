    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POC1;
using POC1.coreAPI.Delegates;
using POC1.coreAPI.Services;
using POC1.Entities1;
using POC1.Persistance1;

namespace POC1.core.Services
{
    public class ArtServices : IArtServices
    {
        private readonly IArtRepository _artRepository;

        public ArtServices(IArtRepository artRepository)
        {
            _artRepository = artRepository;
        }

        public Task<IEnumerable<Art>> GetAllAsync()
            => _artRepository.GetAllAsync();

        public Task<Art?> GetByIdAsync(int id)
            => _artRepository.GetByIdAsync(id);

        public Task<Art> CreateAsync(Art art)
        {
            return _artRepository.AddAsync(art);
        }

        public Task<Art?> UpdateAsync(Art art)
        {
            return _artRepository.UpdateAsync(art);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _artRepository.DeleteAsync(id);
        }
    }
}
