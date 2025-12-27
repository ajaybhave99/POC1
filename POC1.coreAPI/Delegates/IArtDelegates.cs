using POC1.Entities1;

namespace POC1.coreAPI.Delegates
{
    public interface IArtDelegates
    {
        Task<IEnumerable<Art>> GetAllAsync();
        Task<Art?> GetByIdAsync(int id);
        Task<Art> CreateAsync(Art art);
        Task<Art?> UpdateAsync(Art art);
        Task<bool> DeleteAsync(int id);
    }

}
