using FindChurch.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindChurch.Infrastructure.Persistence;

public class FindChurchDbContext : DbContext
{
    public FindChurchDbContext(DbContextOptions<FindChurchDbContext> options) : base(options)
    {
    }

    public DbSet<Church> Churches { get; set; }
    public DbSet<Ministry> Ministries { get; set; }
    public DbSet<WorshipService> WorshipServices { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Church>(c =>
            {
                c.HasKey(k => k.Id);

                c.HasMany(w => w.WorshipServices)
                    .WithOne(ws => ws.Church)
                    .HasForeignKey(ws => ws.IdChurch)
                    .OnDelete(DeleteBehavior.Restrict);

                c.HasMany(m => m.Ministry)
                    .WithOne(m => m.Church)
                    .HasForeignKey(m => m.IdChurch)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Ministry>(m =>
            {
                m.HasKey(k => k.Id);

                m.HasMany(mm => mm.Members)
                    .WithOne()
                    .HasForeignKey(mm => mm.IdMinistry)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        builder.Entity<WorshipService>(ws =>
        {
            ws.HasKey(k => k.Id);

            ws.Property(p => p.Day)
                .IsRequired();

            ws.Property(p => p.Time)
                .IsRequired();

            ws.Property(p => p.Service)
                .IsRequired();
        });
    }
}