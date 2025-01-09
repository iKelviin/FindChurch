using FindChurch.Core.Entities;
using FindChurch.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FindChurch.Infrastructure.Persistence.Repositories;

public class MinistryRepository : IMinistryRepository
{
    private readonly FindChurchDbContext _context;

    public MinistryRepository(FindChurchDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ministry>> GetAllAsync()
    {
        var ministries = await _context.Ministries
            .Where(x=> !x.IsDeleted)
            .Include(x=>x.Members)
            .Include(x=>x.Church)
            .ToListAsync();
        return ministries;
    }

    public async Task<List<Ministry>> GetAllByIdChurchAsync(Guid idChurch)
    {
        var ministries = await _context.Ministries
            .Where(x=> x.IdChurch == idChurch && !x.IsDeleted)
            .Include(x=> x.Church)
            .Include(x=> x.Members)
            .ToListAsync();
        return ministries;
    }

    public async Task<Ministry?> GetByIdAsync(Guid id)
    {
        var ministry = await _context.Ministries.Include(x=> x.Members).SingleOrDefaultAsync(x=>x.Id == id);
        return ministry;
    }

    public async Task<Guid> AddAsync(Ministry ministry)
    {
        _context.Ministries.Add(ministry);
        await _context.SaveChangesAsync();
        return ministry.Id;
    }

    public async Task UpdateAsync(Ministry ministry)
    {
        _context.Ministries.Update(ministry);
        await _context.SaveChangesAsync();
    }
}