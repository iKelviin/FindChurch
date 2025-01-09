using FindChurch.Core.Entities;
using FindChurch.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FindChurch.Infrastructure.Persistence.Repositories;

public class ChurchRepository : IChurchRepository
{
    private readonly FindChurchDbContext _context;

    public ChurchRepository(FindChurchDbContext context)
    {
        _context = context;
    }

    public async Task<List<Church>> GetAllAsync()
    {
        var churches = await _context.Churches
            .Where(x => !x.IsDeleted)
            .ToListAsync();
        return churches;
    }

    public async Task<Church?> GetByIdAsync(Guid id)
    {
        var church = await _context.Churches
            .Where(x => !x.IsDeleted)
            .SingleOrDefaultAsync(x=>x.Id == id);
        
        return church;
    }

    public async Task<Guid> AddAsync(Church church)
    {
        _context.Churches.Add(church);
        await _context.SaveChangesAsync();
        return church.Id;
    }

    public async Task UpdateAsync(Church church)
    {
        _context.Churches.Update(church);
        await _context.SaveChangesAsync();
    }
}