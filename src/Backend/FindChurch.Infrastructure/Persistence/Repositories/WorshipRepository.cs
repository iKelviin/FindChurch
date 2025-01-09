using FindChurch.Core.Entities;
using FindChurch.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FindChurch.Infrastructure.Persistence.Repositories;

public class WorshipRepository : IWorshipRepository
{
    private readonly FindChurchDbContext _context;

    public WorshipRepository(FindChurchDbContext context)
    {
        _context = context;
    }

    public async Task<List<WorshipService>> GetAllAsync()
    {
        var worshipServices = await _context.WorshipServices
            .Where(x => !x.IsDeleted)
            .Include(x=> x.Church)
            .ToListAsync();
        return worshipServices;
    }

    public async Task<List<WorshipService>> GetAllByIdChurchAsync(Guid idChurch)
    {
        var worshipServices = await _context.WorshipServices
            .Where(x => !x.IsDeleted && x.IdChurch == idChurch)
            .Include(x=>x.Church)
            .ToListAsync();
        return worshipServices;
    }

    public async Task<WorshipService?> GetByIdAsync(Guid id)
    {
        var worshipService = await _context.WorshipServices.SingleOrDefaultAsync(x=> x.Id == id);
        return worshipService;
    }

    public async Task<Guid> AddAsync(WorshipService worshipService)
    {
        _context.WorshipServices.Add(worshipService);
        await _context.SaveChangesAsync();
        return worshipService.Id;
    }

    public async Task UpdateAsync(WorshipService worshipService)
    {
        _context.WorshipServices.Update(worshipService);
        await _context.SaveChangesAsync();
    }
}