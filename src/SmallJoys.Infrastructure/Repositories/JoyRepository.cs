using Microsoft.EntityFrameworkCore;
using SmallJoys.Application.Abstractions;
using SmallJoys.Domain.Entities;
using SmallJoys.Infrastructure.Data;

namespace SmallJoys.Infrastructure.Repositories;

public class JoyRepository(AppDbContext db) : IJoyRepository
{
    public async Task<IReadOnlyList<Joy>> GetAllAsync() =>
        await db.Joys.OrderByDescending(joy => joy.CreatedAt).ToListAsync();

    public Task<Joy?> GetByIdAsync(int id) =>
        db.Joys.FirstOrDefaultAsync(joy => joy.Id == id);

    public async Task<Joy> AddAsync(Joy joy)
    {
        await db.Joys.AddAsync(joy);
        await db.SaveChangesAsync();
        return joy;
    }

    public async Task<bool> UpdateAsync(Joy joy)
    {
        var exists = await db.Joys.AsNoTracking().AnyAsync(j => j.Id == joy.Id);
        if (!exists) return false;
        db.Joys.Update(joy);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var joy = await db.Joys.FindAsync(id);
        if (joy is null) return false;
        db.Joys.Remove(joy);
        return await db.SaveChangesAsync() > 0;
    }
}
