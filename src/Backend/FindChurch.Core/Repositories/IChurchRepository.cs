using FindChurch.Core.Entities;

namespace FindChurch.Core.Repositories;

public interface IChurchRepository
{
    Task<List<Church>> GetAllAsync();
    Task<Church?> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(Church church);
    Task UpdateAsync(Church church);
}