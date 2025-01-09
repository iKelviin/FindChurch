using FindChurch.Core.Entities;

namespace FindChurch.Core.Repositories;

public interface IMinistryRepository
{
    Task<List<Ministry>> GetAllAsync();
    Task<List<Ministry>> GetAllByIdChurchAsync(Guid idChurch);
    Task<Ministry?> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(Ministry ministry);
    Task UpdateAsync(Ministry ministry);
}