using POC1;
using POC1.core.Services;
using POC1.coreAPI.Delegates;
using POC1.coreAPI.Services;
using POC1.Entities1;
namespace POC1.core.Delegates
{
    public class ArtDelegates : IArtDelegates
    {
        private readonly IArtServices _artServices;

        public ArtDelegates(IArtServices artServices)
        {
            _artServices = artServices;
        }
        public Task<IEnumerable<Art>> GetAllAsync() => _artServices.GetAllAsync();
        public Task<Art?> GetByIdAsync(int id) => _artServices.GetByIdAsync(id);
        public Task<Art> CreateAsync(Art art) => _artServices.CreateAsync(art);
        public Task<Art?> UpdateAsync(Art art) => _artServices.UpdateAsync(art);
        public Task<bool> DeleteAsync(int id) => _artServices.DeleteAsync(id);
    }

}
