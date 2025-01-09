using FindChurch.Core.Entities;

namespace FindChurch.Core.Repositories;

public interface IWorshipRepository
{
    Task<List<WorshipService>> GetAllAsync();
    Task<List<WorshipService>> GetAllByIdChurchAsync(Guid idChurch);
    Task<WorshipService?> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(WorshipService worshipService);
    Task UpdateAsync(WorshipService worshipService);
}